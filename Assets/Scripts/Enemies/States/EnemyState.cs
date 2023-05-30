namespace Enemies.States
{
    public abstract class EnemyState
    {
        protected readonly Enemy enemy;

        protected EnemyState(Enemy enemy)
        {
            this.enemy = enemy;
        }
        
        public abstract void Start();
        public abstract void Execute();
        public abstract void Stop();
    }
}