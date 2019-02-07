using System;
using System.Collections.Generic;
using UnityEngine;

namespace NaturalResources
{
	[Serializable]
	public class ListNaturalResources 
	{
		[SerializeField] public List<NaturalResource> Resources;
		
		public ListNaturalResources()
		{
			Resources = new List<NaturalResource>();
		}

		public NaturalResource GetNaturalResource(NaturalResourcesType type)
		{
			for (int i = 0; i < Resources.Count; i++)
			{
				if (type == Resources[i].Value.Type)
				{
					return Resources[i];
				}
			}

			return null;
		}
	}
}
