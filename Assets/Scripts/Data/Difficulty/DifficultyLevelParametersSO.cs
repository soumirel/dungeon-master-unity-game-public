using System.Collections.Generic;
using Enemies;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "DifficultyLevel", menuName = "SO/Difficulty/DifficultyLevel")]
    public class DifficultyLevelParametersSO : ScriptableObject
    {
        [SerializeField] private float _minSpawnInterval;
        [SerializeField] private float _maxSpawnInterval;

        [SerializeField] private int _totalCost;
        [SerializeField] private List<EnemyType> _enemyTypes;

        public float MinSpawnInterval => _minSpawnInterval;
        public float MaxSpawnInterval => _maxSpawnInterval;
        public int TotalCost => _totalCost;
        public List<EnemyType> EnemyTypes => _enemyTypes;
    }
}