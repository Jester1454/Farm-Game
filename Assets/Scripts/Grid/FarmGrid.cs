using System;
using Items.ConsumableFarmItems;
using UnityEngine;

namespace Grid
{
    [Serializable]
    public class FarmGrid 
    {
        [SerializeField] private Vector2Int _gridSize;

        public Vector2Int GridSize
        {
            get { return _gridSize; }
        }
        
        
        [SerializeField] private FarmCell[] _grid;
        
        public FarmGrid(Vector2Int gridSize)
        {
            _gridSize = gridSize;

            _grid = new FarmCell[gridSize.x * gridSize.y];

            for (int i = 0; i < gridSize.x; i++)
            {
                for (int j = 0; j < _gridSize.y; j++)
                {
                    _grid[i * gridSize.x +  j] = new FarmCell(i, j, null);
                }
            }
        }

        public FarmCell GetCell(Vector2Int coordinates)
        {
            if (!CoordinatesInGrid(coordinates))
            {
                return null;
            }

            return _grid[coordinates.x * _gridSize.x + coordinates.y];
        }
        
        public FarmCell GetCell(int x, int y)
        {
            return GetCell(new Vector2Int(x, y));
        }
        
        public bool AddFarmItem(Vector2Int coordinates, ConsumableFarmItem item)
        {
            if (!CoordinatesInGrid(coordinates) || 
                !_grid[coordinates.x * _gridSize.x + coordinates.y].IsEmpty)
            {
                return false;
            }
            
            _grid[coordinates.x * _gridSize.x + coordinates.y] = new FarmCell(coordinates, item);

            return true;
        }

        public bool CoordinatesInGrid(Vector2Int coordinates)
        {
            return !(coordinates.x >= _gridSize.x || coordinates.y >= _gridSize.y ||
                     coordinates.x < 0 || coordinates.y < 0);
        }
    }
}
