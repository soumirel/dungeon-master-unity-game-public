using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies.Spawn
{
    public class EnemyLine
    {
        private readonly Vector2 _spawnPosition;
        private readonly EnemySpawner _spawner;
        private readonly Timer _timer;
        private readonly List<Enemy> _enemies = new();
        
        private List<EnemyType> _allowedTypes;
        
        private Dictionary<EnemyType, int> _costs;
        private int _totalLineCost;
        private int _currentCost;
        
        private float _minSpawnTimeValue = 5f;
        private float _maxSpawnTimeValue = 7f;

        private float RandomSpawnInterval => Random.Range(_minSpawnTimeValue, _maxSpawnTimeValue);

        private Action<Enemy> _enemyDeathHandler;
        
        public bool TurnedOn { get; set; }

        public int TotalCost
        {
            set => _totalLineCost = value;
        }
        
        public List<EnemyType> AllowedTypes
        {
            set => _allowedTypes = value;
        }

        public EnemyLine(EnemySpawner spawner, Vector2 spawnPosition,  Dictionary<EnemyType, int> costs)
        {
            _spawner = spawner;
            _spawnPosition = spawnPosition;
            _costs = costs;
            
            _timer = new Timer(UpdateLine, RandomSpawnInterval);
        }

        public void Update()
        {
            if (TurnedOn)
            {
                _timer.Tick();
            }
        }

        private void UpdateLine()
        {
            _timer.IntervalInSeconds = RandomSpawnInterval;    
            
            if (_currentCost < _totalLineCost)
            {
                List<EnemyType> sortedAllowedTypes = _costs
                    .Where(costs => _allowedTypes.Contains(costs.Key))
                    .OrderByDescending(costs => costs.Value)
                    .Select(costs => costs.Key)
                    .ToList();

                foreach (EnemyType type in sortedAllowedTypes)
                {
                    int cost = _costs[type];

                    _enemyDeathHandler ??= enemyValue => RemoveEnemy(enemyValue, cost);

                    TrySpawnEnemy(type, cost);
                }
            }
        }

        private void TrySpawnEnemy(EnemyType type, int cost)
        {
            if (_currentCost + cost <= _totalLineCost)
            {
                Enemy enemy = _spawner.TrySpawn(type, _spawnPosition);

                if (enemy)
                {
                    AddEnemy(enemy, cost);
                }
            }
        }
        
        private void AddEnemy(Enemy enemy, int cost)
        {
            _enemies.Add(enemy);
            _currentCost += cost;
            
            enemy.Died += _enemyDeathHandler;
        }

        private void RemoveEnemy(Enemy enemy, int cost)
        {
            _enemies.Remove(enemy);
            _currentCost -= cost;

            enemy.Died -= _enemyDeathHandler;
        }
        
        public void SetSpawnRange(float minTimeValue, float maxTimeValue)
        {
            _minSpawnTimeValue = minTimeValue;
            _maxSpawnTimeValue = maxTimeValue;
        }
    }
}