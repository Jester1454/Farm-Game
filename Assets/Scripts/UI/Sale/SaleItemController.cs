using GameController;
using NaturalResources;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Sale
{
	public class SaleItemController : MonoBehaviour
	{
		[SerializeField] private NaturalResourcesType _type;
		[SerializeField] private Button _saleButtton;
		[SerializeField] private Text _countText;
		
		private NaturalResource _naturalResources;
		public NaturalResourcesType Type
		{
			get { return _type; }
		}
		
		public void Initialization(NaturalResource naturalResources)
		{
			FarmingGameController.ChangeResourcesAction += UpdateText;
			_naturalResources = naturalResources;
			_saleButtton.onClick.AddListener(SaleResource);
		}

		private void SaleResource()
		{
			NaturalResourceValue naturalResourceValue = 
				new NaturalResourceValue(_naturalResources.Value.Type, 1);
			
			if (FarmingGameController.CurrentGame.GetNaturalResources(naturalResourceValue.Type).Quantity > 0)
			{
				FarmingGameController.ChangeResources(naturalResourceValue, true);
				FarmingGameController.ChangeMoney(_naturalResources.UnitPrice);
			}
			
			UpdateText(_type);
		}

		private void UpdateText(NaturalResourcesType type)
		{
			if (type == _type)
			{
				_countText.text = FarmingGameController.CurrentGame.GetNaturalResources(type).Quantity.ToString();
			}
		}
	}
}
