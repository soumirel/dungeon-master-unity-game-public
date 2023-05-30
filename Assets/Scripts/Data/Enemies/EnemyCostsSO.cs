using UnityEngine;

namespace Data.Enemies
{
    [CreateAssetMenu(fileName = "EnemyCosts", menuName = "SO/EnemySO/Costs")]
    public class EnemyCostsSO : ScriptableObject
    {
        [SerializeField] private int _basicEnemyCost;
        [SerializeField] private int _fastEnemyCost;
        [SerializeField] private int _heavyEnemyCost;
        [SerializeField] private int _eliteFastEnemyCost;
        [SerializeField] private int _eliteHeavyEnemyCost;

        public int BasicEnemyCost => _basicEnemyCost;
        public int FastEnemyCost => _fastEnemyCost;
        public int HeavyEnemyCost => _heavyEnemyCost;
        public int EliteFastEnemyCost => _eliteFastEnemyCost;
        public int EliteHeavyEnemyCost => _eliteHeavyEnemyCost;
    }
}