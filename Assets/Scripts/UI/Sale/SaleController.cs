using System.Collections.Generic;
using GameController;
using NaturalResources;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Sale
{
    public class SaleController : MonoBehaviour
    {
        private ListNaturalResources _resources;
        [SerializeField] private Text _moneyText;
        [SerializeField] private List<SaleItemController> _saleItemControllers;
        
        public void Initialization(ListNaturalResources resources)
        {
            _resources = resources;
            FarmingGameController.ChangeMoneyAction += MoneyUpdate;

            for (int i = 0; i < _saleItemControllers.Count; i++)
            {
                _saleItemControllers[i].Initialization(_resources.GetNaturalResource(_saleItemControllers[i].Type));
            }

            MoneyUpdate();
        }

        private void MoneyUpdate()
        {
            _moneyText.text = FarmingGameController.CurrentGame.Money.ToString();
        }
    }
}
