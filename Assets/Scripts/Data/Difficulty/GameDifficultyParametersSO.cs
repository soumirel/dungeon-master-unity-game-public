using System.Collections.Generic;
using Data.Enemies;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "GameDifficulty", menuName = "SO/Difficulty/GameDifficulty")]

    public class GameDifficultyParametersSO : ScriptableObject
    {
        [SerializeField] private EnemyCostsSO _enemyCostsSo;
      
        [SerializeField] private AnimationCurve _difficultyCurve;
        [SerializeField] private float _curveStep;
        
        [SerializeField] private float _increaseDifficultyLevelInterval;
        [SerializeField] private List<CurveLevelDifficultySO> _curveLevelDifficulties;

        public EnemyCostsSO EnemyCostSo=> _enemyCostsSo;
        public AnimationCurve DifficultyCurve => _difficultyCurve;
        public float CurveStep => _curveStep;
        public float IncreaseDifficultyLevelInterval => _increaseDifficultyLevelInterval;
        public List<CurveLevelDifficultySO> CurveLevelDifficulties => _curveLevelDifficulties;
    }
}