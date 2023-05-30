using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(RectTransform))]
    public sealed class GameField : MonoBehaviour
    {
        [SerializeField] private Button _buttonPrefab;
        [SerializeField] private GameFieldParametersSO _fieldParametersSo;

        private FieldCell[,] _cells;

        private int _rowCount;
        private int _columnCount;

        public int RowCount => _rowCount;
        public int ColumnCount => _columnCount;

        public Vector2 GetRowSize()
        {
            var cellSize = CalculateCellSize();
            float width = cellSize.x * _columnCount;
            float heigh = cellSize.y;
            return new Vector2(width, heigh);
        }

        public Vector2 GetColumnSize()
        {
            var cellSize = CalculateCellSize();
            float width = cellSize.x;
            float heigh = cellSize.y * _rowCount;
            return new Vector2(width, heigh);
        }

        public Vector2 GetRowCenter(int rowNumber)
        {
            var rectTransform = GetComponent<RectTransform>();
            var topCenterPosition = rectTransform.position + new Vector3(0f, rectTransform.rect.yMax);
            var cellHeight = CalculateCellSize().y;
            return topCenterPosition + new Vector3(0f, cellHeight * (rowNumber + 0.5f));
        }


        public void Awake()
        {
            InitializeFieldParameters();
            GenerateField();
        }

        private void InitializeFieldParameters()
        {
            _rowCount = _fieldParametersSo.RowsCount;
            _columnCount = _fieldParametersSo.ColumnsCount;
        }

        private Vector2 CalculateCellSize()
        {
            var rect = GetComponent<RectTransform>().rect;
            var cellWidth = rect.size.x / _columnCount;
            var cellHeight = rect.size.y / _rowCount;
            return new Vector2(cellWidth, cellHeight);
        }


        private void GenerateField()
        {
            _cells = new FieldCell[_rowCount, _columnCount];

            var buttonSize = CalculateCellSize();

            for (int row = 0; row < _rowCount; row++)
            {
                for (int col = 0; col < _columnCount; col++)
                {
                    var button = CreateButtonByGrid(buttonSize, row, col);
                    var cell = new FieldCell(button, row, col);
                    _cells[row, col] = cell;
                }
            }
        }

        private Button CreateButtonByGrid(Vector2 buttonSize, int row, int column)
        {
            var button = Instantiate(_buttonPrefab, transform);
            var buttonRectTransform = button.GetComponent<RectTransform>();

            buttonRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, buttonSize.x);
            buttonRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, buttonSize.y);

            buttonRectTransform.anchorMax = Vector2.zero;
            buttonRectTransform.anchorMin = Vector2.zero;

            buttonRectTransform.anchoredPosition = new Vector2(
                column * buttonSize.x + buttonSize.x / 2,
                row * buttonSize.y + buttonSize.y / 2);

            button.name = "Button " + column + ":" + row;

            return button;
        }

        public List<Vector2> GetEnemySpawnPoints()
        {
            List<Vector2> positions = new();
            Vector2 offset = Vector2.right * 3f;

            for (int i = 0; i < _rowCount; i++)
            {
                Vector2 position = _cells[i, _columnCount - 1].CenterCoordinates + offset;
                positions.Add(position);
            }

            return positions;
        }
    }
}