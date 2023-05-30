using System;
using UnityEngine;

namespace Enemies.Spawn
{
    [Serializable]
    public class EnemyPoolData
    {
        [SerializeField] private EnemyType _type;
        [SerializeField] private int _count;

        public EnemyType Type => _type;
        public int Count => _count;
    }
}