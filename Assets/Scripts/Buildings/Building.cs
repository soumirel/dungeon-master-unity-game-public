using System;
using Elements;
using UnityEngine;

namespace Buildings
{
    public abstract class Building : MonoBehaviour, IEnemyTarget
    {
        public event Action<float> OnAbsoluteHealthValueChanged;

        protected Element element;
        protected float maxHealth;

        protected Health health;

        public ElementType ElementType => element.ElementType;

        public void TakeDamage(float damage)
        {
            health.Value -= damage;
            OnAbsoluteHealthValueChanged?.Invoke(health.AbsoluteValue);

            if (health.Value <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}