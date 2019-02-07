using System;
using Items;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    [RequireComponent(typeof(Button))]
    public class ShopItemController : MonoBehaviour
    {
        [SerializeField] private FarmItemType _itemType;

        public FarmItemType ItemType
        {
            get { return _itemType; }
        }
            
        [SerializeField] private Text _costLabel;
        private ShopItem _shopItem;
        
        public static Action<ShopItem> Buy;
        
        public void Initialization(ShopItem item)
        {
            _shopItem = item;
            UpdateView();
        }

        private void BuyClick()
        {
            Buy.CallActionIfNotNull(_shopItem);
        }

        private void UpdateView()
        {
            GetComponent<Button>().onClick.AddListener(BuyClick);
            _costLabel.text = _shopItem.Cost.ToString();
        }

        private void OnDestroy()
        {
            Buy = null;
        }
    }
}
