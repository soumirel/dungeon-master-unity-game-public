using UnityEngine;

namespace Enemies.Spawn
{
    public class EnemySpawner
    {
        private readonly EnemyPool _enemyPool;

        public EnemySpawner(EnemyPool enemyPool)
        {
            _enemyPool = enemyPool;
        }
        
        public Enemy TrySpawn(EnemyType type, Vector2 position)
        {
            var enemy = (Enemy)_enemyPool.Get(type);

            if (enemy)
            {
                enemy.transform.position = position;
            }
            
            return enemy;
        }
    }
}