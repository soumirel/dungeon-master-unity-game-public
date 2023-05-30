using Enemies.Spawn;
using UnityEngine;

namespace Enemies
{
    [CreateAssetMenu(fileName = "EnemyFactory", menuName = "SO/EnemySO/Factory")]
    public class EnemyFactory : ScriptableObject
    {
        [SerializeField] private Enemy _basicPrefab;
        [SerializeField] private Enemy _fastPrefab;
        [SerializeField] private Enemy _heavyPrefab;
        [SerializeField] private Enemy _eliteFastPrefab;
        [SerializeField] private Enemy _eliteHeavy;

        public Enemy Get(EnemyType type)
        {
            return type switch
            {
                EnemyType.Basic => Instantiate(_basicPrefab),
                EnemyType.Fast => Instantiate(_fastPrefab),
                EnemyType.Heavy => Instantiate(_heavyPrefab),
                EnemyType.EliteFast => Instantiate(_eliteFastPrefab),
                EnemyType.EliteHeavy => Instantiate(_eliteHeavy),
                _ => null
            };
        }
    }
}