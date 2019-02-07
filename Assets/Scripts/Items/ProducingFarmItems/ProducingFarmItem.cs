using System;
using NaturalResources;
using UnityEngine;

namespace Items.ProducingFarmItems
{
    [Serializable]
    public class ProducingFarmItem : IFarmItem, IProducingFarmItem 
    {
        public FarmItemType ItemType
        {
            get { return _itemType; }
            set { _itemType = value; }
        }
        [SerializeField] private FarmItemType _itemType;

        public NaturalResourceValue ProducingResourcesValue         
        {
            get { return _producingResourcesValue; }
            set { _producingResourcesValue = value; }
        }
        [SerializeField] private NaturalResourceValue _producingResourcesValue;

        
        public float ProducingRecycleTime 
        {
            get { return _producingRecycleTime; }
            set { _producingRecycleTime = value; }
        }
        [SerializeField] private float _producingRecycleTime;

        public float CurrentProducingRecycleTime 
        {
            get { return _currentProducingRecycleTime; }
            set { _currentProducingRecycleTime = value; }
        }
        [SerializeField] private float _currentProducingRecycleTime;

        public ProducingFarmItem(FarmItemType type, NaturalResourceValue resourceValue, float producingRecycleTime,
            float currentRecycleTime = 0)
        {
            ItemType = type;
            ProducingResourcesValue = resourceValue;
            ProducingRecycleTime = producingRecycleTime;
            CurrentProducingRecycleTime = currentRecycleTime;
        }
        
        public NaturalResourceValue GetResources()
        {
            if (CurrentProducingRecycleTime >= ProducingRecycleTime)
            {
                return ProducingResourcesValue;
            }
            
            return new NaturalResourceValue(ProducingResourcesValue.Type, 0);
        }
    }
}
