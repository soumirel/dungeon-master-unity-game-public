using Elements;
using UnityEngine;
using UnityEngine.Serialization;

namespace Data
{
    public abstract class BuildingParametersSO : ScriptableObject
    {
        [SerializeField] protected ElementType elementType = ElementType.None;
        [SerializeField] protected float maxHealth = 0;
        [SerializeField] protected int cost;

        [SerializeField] protected Sprite baseSprite;
        
        public float MaxHealth => maxHealth;
        public ElementType ElementType => elementType;
        public int Cost => cost;
        public Sprite BaseSprite => baseSprite;
    }
}