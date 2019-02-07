using System;
using System.Collections.Generic;
using UnityEngine;

namespace Items.ConsumableFarmItems
{
	[Serializable]
	public class ConsumableFarmItemList
	{
		[SerializeField] private List<ConsumableFarmItem> _consumableFarmItems;

		public List<ConsumableFarmItem> ConsumableFarmItems
		{
			get { return _consumableFarmItems; }
		}

		public ConsumableFarmItemList()
		{
			_consumableFarmItems = new List<ConsumableFarmItem>();
		}
	}
}
