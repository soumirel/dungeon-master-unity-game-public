using Buildings;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class FieldCell
    {
        private Vector2 _centerCoordinates;
        private Building _building;
        
        //TODO: Зарефакторить принцип BuildingType. Решение выглядит как костыль
        private BuildingType _buildingType;
        
        private int _row;
        private int _column;


        public FieldCell(Button button, int row, int column)
        {
            _centerCoordinates = button.transform.TransformPoint(Vector3.zero);
            button.onClick.AddListener(OnButtonClicked);
            
            _row = row;
            _column = column;

            _building = null;
            _buildingType = BuildingType.None;
        }

        public int Row => _row;
        public int Column => _column;

        public BuildingType BuildingType => _buildingType;
        
        public Building Building => _building;

        public Vector2 CenterCoordinates => _centerCoordinates;

        public bool isEmpty() => _building == null;

        public void SetBuilding(Building building, BuildingType buildingType)
        {
            if (_building == null)
            {
                _building = building;
                _buildingType = buildingType;
            }
        }

        public void RemoveBuilding()
        {
            _building = null;
            _buildingType = BuildingType.None;
        }

        private void OnButtonClicked()
        {
            EventManager.InvokeOnCellClicked(this);
        }
    }
}