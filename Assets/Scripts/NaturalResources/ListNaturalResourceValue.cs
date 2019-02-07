using System;
using System.Collections.Generic;
using UnityEngine;

namespace NaturalResources
{
	[Serializable]
	public class ListNaturalResourceValue 
	{
		[SerializeField] public List<NaturalResourceValue> Resources;
		
		public ListNaturalResourceValue()
		{
			Resources = new List<NaturalResourceValue>();
		}
	}
}
