using System.Collections.Generic;
using Items;
using Items.ConsumableFarmItems;
using Shop;
using UnityEngine;

namespace Grid
{
    public class GridController : MonoBehaviour
    {
        [SerializeField] private List<ConsumableFarmItemController> _farmItemControllers;
        [SerializeField] private CellController _cellPrefab;
        [SerializeField] private Vector2 _cellOffset = new Vector2(0.2f, 0.2f);

        private CellController[,] _cellGrid;
        private FarmGrid _grid;

        private ConsumableFarmItemController _chooseFarmItemController;
        private bool _chooseCellForItem = false;
        
        public void Initialization(FarmGrid grid)
        {
            _grid = grid;
            _cellGrid = new CellController[_grid.GridSize.x, _grid.GridSize.y];
            CreateGrid();

            CellController.OnClick += ClickOnCell;
            CellController.OnCellEnter += EnterInCell;
            ShopController.BuyFarmItem += StartChoosenCellForItem;
        }

        private void CreateGrid()
        {
            Vector2 size = _cellPrefab.GetComponent<BoxCollider2D>().size + _cellOffset;
        
            Vector2 cellPosition = transform.position;
            
            for (int i = 0; i < _grid.GridSize.x; i++)
            {
                for (int j = 0; j < _grid.GridSize.y; j++)
                {
                    FarmCell cell = _grid.GetCell(i, j);
                    
                    _cellGrid[i, j] = Instantiate(_cellPrefab, cellPosition, Quaternion.identity, transform);
                    _cellGrid[i, j].Initialization(cell);

                    if (!cell.IsEmpty)
                    {
                        _cellGrid[i, j]
                            .CreateFarmItem(GetItem(cell.CellItem.ItemType), cell.CellItem);
                    }
                    
                    cellPosition.x += size.x;
                }

                cellPosition.y += size.y;
                cellPosition.x = transform.position.x;
            }
        }

        private void StartChoosenCellForItem(ShopItem shopItem)
        {
            _chooseFarmItemController = GetItem(shopItem.ItemType);
            _chooseCellForItem = true;
        }

        private void ClickOnCell(FarmCell cell)
        {
            if (cell == null)
            {
                return;
            }

            if (cell.IsEmpty && _chooseCellForItem)
            {
                _cellGrid[cell.Coordinates.x, cell.Coordinates.y]
                    .CreateFarmItem(_chooseFarmItemController);
                
                _chooseCellForItem = false;
                _chooseFarmItemController = null;
            }
        }

        private void EnterInCell(FarmCell cell)
        {
            if (cell == null)
            {
                return;
            }

            if (cell.IsEmpty && _chooseCellForItem)
            {
                _cellGrid[cell.Coordinates.x, cell.Coordinates.y]
                    .CreateChooseItem(_chooseFarmItemController.gameObject);
            }
        }
        
        private ConsumableFarmItemController GetItem(FarmItemType type)
        {
            for (int i = 0; i < _farmItemControllers.Count; i++)
            {
                if (_farmItemControllers[i].Type == type)
                {
                    return _farmItemControllers[i];
                }
            }

            return null;
        }
    }
}
