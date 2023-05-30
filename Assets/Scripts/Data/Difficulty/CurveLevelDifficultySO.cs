using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CurveDifficulty", menuName = "SO/Difficulty/CurveDifficulty")]
    public class CurveLevelDifficultySO : ScriptableObject
    {
        [SerializeField] private float _height;
        [SerializeField] private DifficultyLevelParametersSO _difficultyLevelParameters;

        public float Height => _height;
        public DifficultyLevelParametersSO DifficultyLevelParameters => _difficultyLevelParameters;
    }
}