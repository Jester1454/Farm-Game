using System;
using GameController;
using Items.ConsumableFarmItems;
using UnityEngine;

namespace Grid
{
    [RequireComponent(typeof(Collider2D))]
    public class CellController : MonoBehaviour
    {
        private FarmCell _farmCell;
        private GameObject _chooseObject;
        
        public static Action<FarmCell> OnClick;
        public static Action<FarmCell> OnCellEnter;
            
        public void Initialization(FarmCell farmCell)
        {
            _farmCell = farmCell;
        }
        
        private void OnMouseEnter()
        {
            OnCellEnter.CallActionIfNotNull(_farmCell);
        }

        private void OnMouseExit()
        {
            if (_chooseObject != null)
            {
                Destroy(_chooseObject);
            }
        }

        private void OnMouseDown()
        {
            OnClick.CallActionIfNotNull(_farmCell);
            OnMouseExit();
        }


        public void CreateChooseItem(GameObject item)
        {
            _chooseObject = Instantiate(item, transform);
        }

        public void CreateFarmItem(ConsumableFarmItemController farmItemController)
        {
            ConsumableFarmItem farmItem = FarmingGameController.GetItemStats(farmItemController.Type);
            _farmCell.SetConsumableFarmItem(farmItem);
            Instantiate(farmItemController, transform).Initiazliation(farmItem);
        }
        
        public void CreateFarmItem(ConsumableFarmItemController farmItemController, ConsumableFarmItem farmItem)
        {
            Instantiate(farmItemController, transform).Initiazliation(farmItem);
        }
        
        private void OnDestroy()
        {
            OnClick = null;
            OnCellEnter = null;
        }
    }
}
