using System;
using Items;
using UnityEngine;

namespace Shop
{
	[Serializable]
	public class ShopItem
	{
		[SerializeField] private float _cost;

		public float Cost
		{
			get { return _cost; }
		}
		
		[SerializeField] private FarmItemType _itemType;

		public FarmItemType ItemType
		{
			get { return _itemType; }
		}

		public ShopItem(FarmItemType type, float cost)
		{
			_itemType = type;
			_cost = cost;
		}
	}
}
