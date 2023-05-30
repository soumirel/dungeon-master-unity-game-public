using System;
using Data.Enemies;
using Enemies.Spawn;
using Enemies.States;
using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Enemies
{
    [RequireComponent(typeof(EnemyBehaviour))]
    public class Enemy : MonoBehaviour, IPoolObject, IDamagable
    {
        public event Action<float> OnAbsoluteHealthValueChanged;

        [SerializeField] private EnemyParametersSO _enemyParametersSo;

        private EnemyBehaviour _behaviour;

        private Health _health;
        private float _speed;
        private float _damage;
        private float _cooldown;
        private int _reward;

        private Animator _animator;
        private static readonly int DieTriggerParam = Animator.StringToHash("die");
        private static readonly int HitTriggerParam = Animator.StringToHash("hit");

        private bool _inPoolUse;

        public float Speed => _speed;
        public float Damage => _damage;
        public float Cooldown => _cooldown;
        public Animator Animator => _animator;

        public bool InUse
        {
            get => _inPoolUse;
            set
            {
                _inPoolUse = value;
                gameObject.SetActive(value);
            }
        }

        public event Action<Enemy> Died;

        private void Awake()
        {
            _behaviour = GetComponent<EnemyBehaviour>();
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            SetSoParameters(_enemyParametersSo);
            _behaviour.Initialize(this);
        }

        private void SetSoParameters(EnemyParametersSO enemyParametersSo)
        {
            _health = new Health(enemyParametersSo.MaxHealth);
            _speed = enemyParametersSo.Speed;
            _damage = enemyParametersSo.Damage;
            _cooldown = enemyParametersSo.Cooldown;
            _reward = enemyParametersSo.Reward;
        }

        public void TakeDamage(float damage)
        {
            _health.Value -= damage;
            _animator.SetTrigger(HitTriggerParam);
            OnAbsoluteHealthValueChanged?.Invoke(_health.AbsoluteValue);

            if (_health.Value <= 0)
            {
                Die();
            }
        }


        private void Die()
        {
            _animator.SetTrigger(DieTriggerParam);
            Died?.Invoke(this);

            //TODO: Зарефакторить систему передачи награды
            EventManager.InvokeOnEnemyDied(_reward);
        }

        public void Clear()
        {
            SetSoParameters(_enemyParametersSo);
            _health.Reset();
            OnAbsoluteHealthValueChanged?.Invoke(_health.AbsoluteValue);
            gameObject.SetActive(false);
        }
    }
}