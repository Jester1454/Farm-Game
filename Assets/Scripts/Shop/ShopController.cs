using System;
using System.Collections.Generic;
using GameController;
using Items;
using UnityEngine;

namespace Shop
{
	public class ShopController : MonoBehaviour
	{
		[SerializeField] private List<ShopItemController> _shopItemControllers;
		[SerializeField] private Transform _itemsContainer;
		private ShopItemList _itemList;

		public static Action<ShopItem> BuyFarmItem;
		
		public void Initialization(ShopItemList itemList)
		{
			_itemList = itemList;
			FillShopController();
			ShopItemController.Buy += BuyItem;
		}

		private void FillShopController()
		{
			for (int i = 0; i < _itemList.ItemList.Count; i++)
			{
				ShopItemController controller = GetItem(_itemList.ItemList[i].ItemType);
				if (controller != null)
				{
					Instantiate(controller, _itemsContainer).Initialization(_itemList.ItemList[i]);
				}
			}
		}

		private void BuyItem(ShopItem item)
		{
			if (item == null)
			{
				return;
			}
			
			if (item.Cost <= FarmingGameController.CurrentGame.Money)
			{
				FarmingGameController.ChangeMoney(item.Cost, true);
				
				BuyFarmItem.CallActionIfNotNull(item);
			}
		}
		
		private ShopItemController GetItem(FarmItemType type)
		{
			for (int i = 0; i < _shopItemControllers.Count; i++)
			{
				if (_shopItemControllers[i].ItemType == type)
				{
					return _shopItemControllers[i];
				}
			}

			return null;
		}

		private void OnDestroy()
		{
			BuyFarmItem = null;
		}
	}
}
