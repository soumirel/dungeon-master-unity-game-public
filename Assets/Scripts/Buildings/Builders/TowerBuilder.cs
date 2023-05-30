using System;
using System.Collections.Generic;
using Data;
using Elements;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

namespace Buildings.Builders
{
    public class TowerBuilder : Builder
    {
        protected override Building BuildConcrete(Element element, BuildingParametersSO preset, Vector2 position)
        {
            if (preset is TowerParametersSO towerPreset)
            {
                Tower newTower = Instantiate(buildingPrefab, position, Quaternion.identity) as Tower;
                newTower.Initialize(element, towerPreset.MaxHealth, towerPreset.ShotsInterval,
                    towerPreset.BaseSprite, towerPreset.AnimatorController);
                newTower.transform.SetParent(transform);
                return newTower;
            }

            return null;
        }
    }
}