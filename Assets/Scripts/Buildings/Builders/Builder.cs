using System.Collections.Generic;
using Data;
using Elements;
using UnityEngine;
using UnityEngine.Serialization;

namespace Buildings.Builders
{
    public abstract class Builder : MonoBehaviour
    {
        [SerializeField] protected Building buildingPrefab;
        [SerializeField] protected ElementsSystem elementsSystem;

        protected Dictionary<ElementType, BuildingParametersSO> presetsDictionary;
        
        public virtual void Awake()
        {
            presetsDictionary = new Dictionary<ElementType, BuildingParametersSO>();
        }

        public void AddPreset(BuildingParametersSO preset)
        {
            presetsDictionary.TryAdd(preset.ElementType, preset);
        }

        public Building Build(ElementType elementType, Vector2 position)
        {
            if (presetsDictionary.TryGetValue(elementType, out var preset)
                && elementsSystem.TryGetElement(elementType, out var element))
            {
                return BuildConcrete(element, preset, position);
            }

            return null;
        }

        public int GetBuildingCost(ElementType elementType)
        {
            if (presetsDictionary.TryGetValue(elementType, out var preset))
            {
                return preset.Cost;
            }
            return -1;
        }

        protected abstract Building BuildConcrete(Element element, BuildingParametersSO preset, Vector2 position);
    }
}