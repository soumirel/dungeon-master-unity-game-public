using System.Collections.Generic;
using Enemies;
using UnityEngine;

namespace Buildings
{
    [RequireComponent(typeof(Collider2D))]
    public class TowerLine : MonoBehaviour
    {
        private List<Tower> _towers;
        
        private int _detectedEnemiesCount;

        public void Awake()
        {
            _towers = new List<Tower>();
            _detectedEnemiesCount = 0;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out Enemy enemy)) return;
            
            if (_detectedEnemiesCount == 0)
            {
                StartTowersShooting();
            }
            _detectedEnemiesCount += 1;
        }


        public void OnTriggerExit2D(Collider2D other)
        {
            if (!other.TryGetComponent(out Enemy enemy)) return;
            
            _detectedEnemiesCount -= 1;

            if (_detectedEnemiesCount == 0)
            {
                StopTowersShooting();
            }
        }

        public void AddTower(Tower tower)
        {
            _towers.Add(tower);
            if (_detectedEnemiesCount > 0)
            {
                tower.StartShooting();
            }
        }


        public void RemoveTower(Tower tower)
        {
            if (_towers.Contains(tower))
            {
                _towers.Remove(tower);
            }
        }


        private void StartTowersShooting()
        {
            foreach (var tower in _towers)
            {
                tower.StartShooting();
            }
        }

        private void StopTowersShooting()
        {
            foreach (var tower in _towers)
            {
                tower.StopShooting();
            }
        }
    }
}