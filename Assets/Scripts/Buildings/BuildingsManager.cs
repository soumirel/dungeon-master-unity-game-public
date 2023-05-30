using System;
using System.Collections.Generic;
using Buildings.Builders;
using Data;
using Elements;
using UI;
using UnityEngine;

namespace Buildings
{
    public class BuildingsManager : MonoBehaviour
    {
        [SerializeField] private TowerBuilder _towerBuilder;
        [SerializeField] private LensBuilder _lensBuilder;

        [SerializeField] private TowerParametersSO[] _towerPresets;
        [SerializeField] private LensParametersSO[] _lensPresets;

        [SerializeField] private TowerLine[] _towerLines;

        private Dictionary<BuildingType, Builder> _builders;


        public void Awake()
        {
            _builders = new Dictionary<BuildingType, Builder>();
            _builders.TryAdd(BuildingType.Tower, _towerBuilder);
            _builders.TryAdd(BuildingType.Lens, _lensBuilder);
        }

        public void Start()
        {
            InitializeBuilders();
        }


        private void InitializeBuilders()
        {
            foreach (var towerPreset in _towerPresets)
            {
                _towerBuilder.AddPreset(towerPreset);
            }

            foreach (var lensPreset in _lensPresets)
            {
                _lensBuilder.AddPreset(lensPreset);
            }
        }

        public int GetBuildingCost(BuildingType buildingType, ElementType elementType)
        {
            return _builders[buildingType].GetBuildingCost(elementType);
        }

        public Building Build(FieldCell cell, BuildingType buildingType, ElementType elementType)
        {
            var building = _builders[buildingType].Build(elementType, cell.CenterCoordinates);
            if (buildingType == BuildingType.Tower)
            {
                _towerLines[cell.Row].AddTower(building as Tower);
            }

            return building;
        }


        public void Destroy(FieldCell cell)
        {
            if (cell.Building is Tower tower)
            {
                _towerLines[cell.Row].RemoveTower(tower);
            }
            Destroy(cell.Building.gameObject);
            cell.RemoveBuilding();
        }
    }
}