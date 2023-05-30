using Elements;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ElementSO", menuName = "SO/ElementSO")]
    public class ElementParametersSO : ScriptableObject
    {
        [SerializeField] private ElementType _elementType = ElementType.None;
        [SerializeField] private float _damageScale = 1f;
        [SerializeField] private float _speedScale = 1f;
        [SerializeField] private RuntimeAnimatorController _animatorController;


        public ElementType ElementType => _elementType;
        public float DamageScale => _damageScale;
        public float SpeedScale => _speedScale;
        public RuntimeAnimatorController AnimatorController => _animatorController;
    }
}