using UnityEngine;

namespace Elements
{
    public sealed class Element
    { 
        private ElementType _elementType;
        private float _damageScale;
        private float _speedScale;
        private RuntimeAnimatorController _animatorController;


        public ElementType ElementType => _elementType;

        public float SpeedScale => _speedScale;

        public float DamageScale => _damageScale;

        public RuntimeAnimatorController AnimatorController => _animatorController;

        public Element(ElementType elementType, float damageScale, float speedScale,
            RuntimeAnimatorController animatorController)
        {
            _elementType = elementType;
            _damageScale = damageScale;
            _speedScale = speedScale;
            _animatorController = animatorController;
        }

        public void ApplyDamage(IDamagable target)
        {
            target.TakeDamage(_damageScale);
        }
    }
}