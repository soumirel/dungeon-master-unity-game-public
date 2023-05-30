using System.Collections.Generic;
using UnityEngine;

namespace Enemies.Spawn
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private EnemyFactory _factory;
        [SerializeField] private List<EnemyPoolData> _enemyData;

        private Dictionary<EnemyType, List<IPoolObject>> _enemies;
        
        public void Initialize()
        {
            _enemies = new Dictionary<EnemyType, List<IPoolObject>>();
            
            foreach (EnemyPoolData enemyData in _enemyData)
            {
                _enemies[enemyData.Type] = new List<IPoolObject>();
                
                for (int i = 0; i < enemyData.Count; i++)
                {
                    Enemy enemy = _factory.Get(enemyData.Type);
                    
                    enemy.transform.parent = transform;
                    enemy.Died += Release;
                    enemy.InUse = false;
                    
                    _enemies[enemyData.Type].Add(enemy);
                }
            }
        }

        public IPoolObject Get(EnemyType type)
        {
            foreach (IPoolObject enemy in _enemies[type])
            {
                if (enemy.InUse == false)
                {
                    enemy.InUse = true;
                    return enemy;
                }
            }
            
            return null;
        }
        
        private void Release(IPoolObject poolObject)
        {
            poolObject.Clear();
            poolObject.InUse = false;
        }
    }
}