using UnityEngine;

namespace Enemies.States
{
    public class AttackState : EnemyState
    {
        private readonly IEnemyTarget _enemyTarget;

        private readonly Timer _timer;
        
        private static readonly int AttackTriggerParam = Animator.StringToHash("attack");

        public AttackState(Enemy enemy, IEnemyTarget enemyTarget) : base(enemy)
        {
            _enemyTarget = enemyTarget;
            _timer = new Timer(Attack, enemy.Cooldown);
        }

        public override void Start() {}

        public override void Execute()
        {
            _timer.Tick();
        }

        public override void Stop() {}

        private void Attack()
        {
            enemy.Animator.SetTrigger(AttackTriggerParam);
            Attack(_enemyTarget);
        }
        
        private void Attack(IEnemyTarget target)
        {
            target.TakeDamage(enemy.Damage);
        }
    }
}