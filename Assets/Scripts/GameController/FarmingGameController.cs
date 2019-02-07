using System;
using Config;
using Grid;
using Items;
using Items.ConsumableFarmItems;
using NaturalResources;
using Saves;
using Shop;
using UI.Sale;
using UnityEngine;

namespace GameController
{
	public class FarmingGameController : MonoBehaviour
	{
		private ListNaturalResources _resources;
		private ShopItemList _shopItemList;
		private static ConsumableFarmItemList farmItemList;
		private static Game currentGame;
		
		public static Game CurrentGame
		{
			get { return currentGame; }
		}

		private SavesController _saveController;
		[SerializeField] private GridController _gridController;
		[SerializeField] private ShopController _shopController;
		[SerializeField] private SaleController _saleController;

		public static Action<NaturalResourcesType> ChangeResourcesAction;
		public static Action ChangeMoneyAction;
		
		private void Awake()
		{
			InitializationGame();
		}

		private void InitializationGame()
		{
			InitialDateFromConfig();
			LoadGameFromSaves();
			_gridController.Initialization(currentGame.FarmGrid);
			_shopController.Initialization(_shopItemList);
			_saleController.Initialization(_resources);
		}

		private void Start()
		{
			UpdateCounters();
		}

		private void UpdateCounters()
		{
			ChangeMoneyAction.CallActionIfNotNull();

			for (int i = 0; i < _resources.Resources.Count; i++)
			{
				ChangeResourcesAction.CallActionIfNotNull(_resources.Resources[i].Value.Type);
			}
		}

		private void InitialDateFromConfig()
		{
			ConfigController configController = new ConfigController();
			
			_resources = configController.GetListNaturalResourcesConfig();
			_shopItemList = configController.GetShopListConfig();
			farmItemList = configController.GetFarmtemsConfig();
		}

		private void LoadGameFromSaves()
		{
			_saveController = new SavesController();
			currentGame = _saveController.Load();
		}

		public static ConsumableFarmItem GetItemStats(FarmItemType type)
		{
			for (int i = 0; i < farmItemList.ConsumableFarmItems.Count; i++)
			{
				if (farmItemList.ConsumableFarmItems[i].ItemType == type)
				{
					return farmItemList.ConsumableFarmItems[i];
				}
			}

			return null;
		}

		public static void ChangeResources(NaturalResourceValue value, bool isSpending = false)
		{
			CurrentGame.ChangeResources(value, isSpending);
			ChangeResourcesAction.CallActionIfNotNull(value.Type);
		}
		
		public static void ChangeMoney(float money, bool isBuy = false)
		{
			CurrentGame.ChangeMoney(money, isBuy);
			ChangeMoneyAction.CallActionIfNotNull();
		}

		private void OnDestroy()
		{
			ChangeMoneyAction = null;
			ChangeResourcesAction = null;
		}
	}
}
