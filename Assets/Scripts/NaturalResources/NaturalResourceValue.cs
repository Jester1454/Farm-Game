using System;
using UnityEngine;

namespace NaturalResources
{
	[Serializable]
	public class NaturalResourceValue
	{
		[SerializeField] private NaturalResourcesType _type;

		public NaturalResourcesType Type
		{
			get { return _type; }
		}
		
		[SerializeField] private int _quantity;
		
		public int Quantity
		{
			get { return _quantity; }
			set { _quantity = value; }
		}

		public NaturalResourceValue(NaturalResourcesType type, int quantity)
		{
			_type = type;
			_quantity = quantity;
		}
	}
}