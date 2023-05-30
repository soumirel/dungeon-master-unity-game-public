using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "TowerSO", menuName = "SO/TowerParametersSO")]
    public class TowerParametersSO : BuildingParametersSO
    {
        [SerializeField] private float _projectileSpeed = 0f;
        [SerializeField] private float _shotsInterval = 0f;
        [SerializeField] private RuntimeAnimatorController _animatorController;

        public float ProjectileSpeed => _projectileSpeed;
        public float ShotsInterval => _shotsInterval;
        public RuntimeAnimatorController AnimatorController => _animatorController;
    }
}