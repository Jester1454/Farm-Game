using System;
using Items.ProducingFarmItems;
using NaturalResources;
using UnityEngine;

namespace Items.ConsumableFarmItems
{
	[Serializable]
	public class ConsumableFarmItem : ProducingFarmItem, IConsumableFarmItem
	{
		public NaturalResourceValue ConsumableResourcesValue 
		{
			get { return _consumableResourcesValue; }
			set { _consumableResourcesValue = value; }
		}		
		[SerializeField] private NaturalResourceValue _consumableResourcesValue;
		
		public float ConsumableRecycleTime
		{
			get { return _consumableRecycleTime; }
			set { _consumableRecycleTime = value; }
		}		
		[SerializeField] private float _consumableRecycleTime;
		
		public float CurrentConsumableRecycleTime
		{
			get { return _currentConsumableRecycleTime; }
			set { _currentConsumableRecycleTime = value; }
		}		
		[SerializeField] private float _currentConsumableRecycleTime;
		
		public ConsumableFarmItem(FarmItemType type, NaturalResourceValue producingResourceValue, float producingRecycleTime,
			NaturalResourceValue consumableResourceValue, float consumableRecycleTime, float currentConsumableRecycleTime = 0, 
			float currentProducingRecycleTime = 0) 
			: base(type, producingResourceValue, producingRecycleTime, currentProducingRecycleTime)
		{
			ConsumableResourcesValue = consumableResourceValue;
			ConsumableRecycleTime = consumableRecycleTime;
			CurrentConsumableRecycleTime = currentConsumableRecycleTime;
		}

		public NaturalResourceValue ConsumeResources()
		{
			CurrentProducingRecycleTime = 0;
			return ConsumableResourcesValue;
		}
	}
}
