using UnityEngine;

namespace FieldBound
{
    [RequireComponent(typeof(Collider2D))]
    public class Bound : MonoBehaviour
    {
        [SerializeField] private BoundType _boundType;

        public BoundType BoundType => _boundType;
    }
}

