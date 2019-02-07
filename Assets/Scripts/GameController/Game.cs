using System;
using System.Collections.Generic;
using Grid;
using NaturalResources;
using UnityEngine;

namespace GameController
{
    [Serializable]
    public class Game
    {
        [SerializeField] private float _money = 0;

        public float Money
        {
            get { return _money; }
        }
        
        [SerializeField] private ListNaturalResourceValue _resources;

        public List<NaturalResourceValue> Resources
        {
            get { return _resources.Resources; }
        }
        
        [SerializeField] private FarmGrid _farmGrid;
        
        public FarmGrid FarmGrid
        {
            get { return _farmGrid; }
        }

        public Game(float startMoney, Vector2Int farmGridSize, List<NaturalResourceValue> startResources = null)
        {
            ChangeMoney(startMoney);
            _farmGrid = new FarmGrid(farmGridSize);
            
            _resources = new ListNaturalResourceValue();
            _resources.Resources = startResources;

            if (_resources.Resources == null)
            {
                _resources.Resources.Add(new NaturalResourceValue(NaturalResourcesType.Eggs, 0));
                _resources.Resources.Add(new NaturalResourceValue(NaturalResourcesType.Hay, 0));
                _resources.Resources.Add(new NaturalResourceValue(NaturalResourcesType.Milk, 0));
            }
        }
        
        public Game(float startMoney, Vector2Int farmGridSize, ListNaturalResourceValue startResources)
        {
            ChangeMoney(startMoney);
            _farmGrid = new FarmGrid(farmGridSize);
            
            _resources = startResources;
        }

        public void ChangeResources(NaturalResourceValue value, bool isSpending = false)
        {
            for (int i = 0; i < _resources.Resources.Count; i++)
            {
                if (_resources.Resources[i].Type == value.Type)
                {
                    var naturalResource = _resources.Resources[i];

                    if (!isSpending)
                    {
                        naturalResource.Quantity += value.Quantity;
                    }
                    else
                    {
                        if (naturalResource.Quantity > 0)
                        {
                            naturalResource.Quantity -= value.Quantity;
                        }
                    }
                }
            }
        }

        public void ChangeMoney(float count, bool isBuy = false)
        {
            if (!isBuy)
            {
                _money += count;
            }
            else
            {
                if (_money > 0)
                {
                    _money -= count;
                }
            }
        }

        public NaturalResourceValue GetNaturalResources(NaturalResourcesType type)
        {
            for (int i = 0; i < _resources.Resources.Count; i++)
            {
                if (_resources.Resources[i].Type == type)
                {
                    return _resources.Resources[i];
                }
            }

            return null;
        }
    }
}
