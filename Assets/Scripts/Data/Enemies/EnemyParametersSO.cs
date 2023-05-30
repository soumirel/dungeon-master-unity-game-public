using UnityEngine;

namespace Data.Enemies
{
    [CreateAssetMenu(fileName = "EnemyParameters", menuName = "SO/EnemySO/Parameters")]
    public class EnemyParametersSO : ScriptableObject
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _speed;
        [SerializeField] private float _damage;
        [SerializeField] private float _cooldown;
        [SerializeField] private int _reward;

        public float MaxHealth => _maxHealth;
        public float Speed => _speed;
        public float Damage => _damage;
        public float Cooldown => _cooldown;
        public int Reward => _reward;
    }
}
