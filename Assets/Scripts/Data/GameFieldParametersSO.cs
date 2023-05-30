using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "GameFieldParametersSO", menuName = "SO/GameFieldParametersSO")]
    public class GameFieldParametersSO : ScriptableObject
    {
        [SerializeField] private int _rowsCount;
        [SerializeField] private int _columnsCount;

        public int RowsCount => _rowsCount;

        public int ColumnsCount => _columnsCount;
    }
}