using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
	[Serializable]
	public class ShopItemList
	{
		[SerializeField] private List<ShopItem> _itemList;

		public List<ShopItem> ItemList
		{
			get { return _itemList; }
		}

		public ShopItemList()
		{
			_itemList = new List<ShopItem>();
		}
	}
}
