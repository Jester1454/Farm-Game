using System;
using UnityEngine;

namespace NaturalResources
{
	[Serializable]
	public class NaturalResource
	{
		[SerializeField] private NaturalResourceValue _value;

		public NaturalResourceValue Value
		{
			get { return _value; }
		}
		
		[SerializeField] private float _unitPrice;

		public float UnitPrice
		{
			get { return _unitPrice; }
		}

		public NaturalResource(NaturalResourceValue value, float price)
		{
			_value = value;
			_unitPrice = price;
		}
		
		public NaturalResource(NaturalResourcesType type, int countResources, float price)
		{
			_value = new NaturalResourceValue(type, countResources);
			_unitPrice = price;
		}
	}
}
