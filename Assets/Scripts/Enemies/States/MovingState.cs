using UnityEngine;

namespace Enemies.States
{
    public class MovingState : EnemyState
    {
        private readonly Vector2 _direction = Vector2.left;
        
        private static readonly int RunBoolParam = Animator.StringToHash("run");

        public MovingState(Enemy enemy) : base(enemy) {}

        public override void Start() {}

        public override void Execute()
        {
            enemy.Animator.SetBool(RunBoolParam, true);
            Move();
        }

        public override void Stop()
        {
            enemy.Animator.SetBool(RunBoolParam, false);
        }

        private void Move()
        {
            enemy.transform.Translate((Vector3)_direction * (enemy.Speed * Time.deltaTime));
        }
    }
}