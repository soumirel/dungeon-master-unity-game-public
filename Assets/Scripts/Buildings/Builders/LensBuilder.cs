using Data;
using Elements;
using UnityEngine;

namespace Buildings.Builders
{
    public class LensBuilder : Builder
    {
        protected override Building BuildConcrete(Element element, BuildingParametersSO preset, Vector2 position)
        {
            if (elementsSystem.TryGetTransformations(element, out var transformations)
                && preset is LensParametersSO lensPreset)
            {
                Lens newLens = Instantiate(buildingPrefab, position, Quaternion.identity) as Lens;
                newLens.Initialize(element, lensPreset.MaxHealth, transformations, lensPreset.BaseSprite, lensPreset.SphereSprite);
                return newLens;
            }

            return null;
        }
    }
}