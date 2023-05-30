using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Enemies;
using UI;
using UnityEngine;

namespace Enemies.Spawn
{
    public class EnemySequenceManager : MonoBehaviour
    {
        [SerializeField] private GameDifficultyParametersSO _gameDifficulty;
        
        private AnimationCurve _difficultyCurve;
        private float _curveStep;
        
        private float _increaseDifficultyLevelInterval;
        private List<CurveLevelDifficultySO> _curveLevelDifficulties;

        private GameField _gameField;
        private EnemyPool _enemyPool;
        
        private EnemySpawner _spawner;
        private List<Vector2> _spawnPositions;

        private List<EnemyLine> _lines;
        
        private EnemyCostsSO _enemyCostsSo;
        
        private Timer _turningLinesOnTimer;
        private int _turnedOnLinesCount;
        
        private Timer _difficultyTimer;
        private float _difficultyEvaluation;
        private float _maxCurveDifficulty;
        
        private void Awake()
        {
            _gameField = FindObjectOfType<GameField>();
            _enemyPool = FindObjectOfType<EnemyPool>();
        }

        private void Start()
        {
            _enemyPool.Initialize();

            _spawner = new EnemySpawner(_enemyPool);
            _spawnPositions = _gameField.GetEnemySpawnPoints();
            
            InitializeGameDifficulty();

            _maxCurveDifficulty = _difficultyCurve.keys[_difficultyCurve.length - 1].time;
            _difficultyTimer = new Timer(IncrementDifficultyLevel, _increaseDifficultyLevelInterval);
            _curveLevelDifficulties = _curveLevelDifficulties
                .OrderBy(difficulty => difficulty.Height)
                .ToList();
            
            InitializeLines();
            SetDifficultyLevelParameters(0);

            _turningLinesOnTimer = new Timer(TurnOnLine, 8);
        }

        private void Update()
        {
            UpdateLines();
            _difficultyTimer.Tick();

            if (_turnedOnLinesCount < _lines.Count)
            {
                _turningLinesOnTimer.Tick();
            }
        }

        private void UpdateLines()
        {
            foreach (EnemyLine line in _lines)
            {
                line.Update();
            }
        }

        private void InitializeGameDifficulty()
        {
            _enemyCostsSo = _gameDifficulty.EnemyCostSo;
            _difficultyCurve = _gameDifficulty.DifficultyCurve;
            _curveStep = _gameDifficulty.CurveStep;
            _increaseDifficultyLevelInterval = _gameDifficulty.IncreaseDifficultyLevelInterval;
            _curveLevelDifficulties = _gameDifficulty.CurveLevelDifficulties;
        }

        private void InitializeLines()
        {
            _lines = new List<EnemyLine>();
            var costs = new Dictionary<EnemyType, int>
            {
                { EnemyType.Basic, _enemyCostsSo.BasicEnemyCost },
                { EnemyType.Fast, _enemyCostsSo.FastEnemyCost },
                { EnemyType.Heavy, _enemyCostsSo.HeavyEnemyCost },
                { EnemyType.EliteFast, _enemyCostsSo.EliteFastEnemyCost },
                { EnemyType.EliteHeavy, _enemyCostsSo.EliteHeavyEnemyCost }
            };

            foreach (Vector2 spawnPosition in _spawnPositions)
            {
                var line = new EnemyLine(_spawner, spawnPosition, costs);
                _lines.Add(line);
            }
        }

        private void IncrementDifficultyLevel()
        {
            _difficultyEvaluation++;

            float curveHeight = _difficultyCurve.Evaluate(_difficultyEvaluation * _curveStep);
            
            if (curveHeight >= _maxCurveDifficulty)
            {
                _difficultyEvaluation = 0;
                curveHeight = _difficultyCurve.Evaluate(0);
            }
            
            SetDifficultyLevelParameters(curveHeight);
        }
        
        private void SetDifficultyLevelParameters(float height)
        {
            CurveLevelDifficultySO curveLevelDifficulty = _curveLevelDifficulties
                .LastOrDefault(level => level.Height <= height);
            
            DifficultyLevelParametersSO difficultyLevelParametersSo = curveLevelDifficulty.DifficultyLevelParameters;
            
            float minSpawnInterval = difficultyLevelParametersSo.MinSpawnInterval;
            float maxSpawnInterval = difficultyLevelParametersSo.MaxSpawnInterval;
            int totalCost = difficultyLevelParametersSo.TotalCost;
            List<EnemyType> enemyTypes = difficultyLevelParametersSo.EnemyTypes;

            foreach (EnemyLine line in _lines)
            {
                line.SetSpawnRange(minSpawnInterval, maxSpawnInterval);
                line.TotalCost = totalCost;
                line.AllowedTypes = enemyTypes;
            }
        }

        private void TurnOnLine()
        {
            var random = new System.Random();
            List<EnemyLine> lines = _lines.ToList();
            EnemyLine line = lines.OrderBy(l => random.Next())
                .ToList()
                .First(l => !l.TurnedOn);

            line.TurnedOn = true;
            _turnedOnLinesCount++;
        }
    }
}