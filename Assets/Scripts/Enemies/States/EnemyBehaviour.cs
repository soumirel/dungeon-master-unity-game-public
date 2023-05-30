using System.Collections.Generic;
using UnityEngine;

namespace Enemies.States
{
    public class EnemyBehaviour : MonoBehaviour
    {
        private List<EnemyState> _states;
        private EnemyState _currentState;
        
        private Enemy _enemy;

        public void Initialize(Enemy enemy)
        {
            _enemy = enemy;
            SwitchState(new MovingState(_enemy));
        }

        private void Update()
        {
            _currentState?.Execute();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out IEnemyTarget target))
            {
                AttackState attackState = new(_enemy, target);
                SwitchState(attackState);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<IEnemyTarget>() != null)
            {
                MovingState movingState = new(_enemy);
                SwitchState(movingState);
            }
        }

        private void SwitchState(EnemyState state)
        {
            _currentState?.Stop();
            state.Start();
            
            _currentState = state;
        }
    }
}