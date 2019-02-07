using System.IO;
using GameController;
using Items.ConsumableFarmItems;
using NaturalResources;
using Shop;
using Utilities;

namespace Config
{
	public class ConfigController
	{
		private static string configsFolder = "Configs";
		private static string shopListConfigPath = "ShopItemListConfig";
		private static string resourcesListConfigPath = "NaturalResourcesListConfig";
		private static string farmItemListConfigPath = "FarmItemListConfig";
		private static string startGameConfigPath = "StartGameConfig";
		
		public Game GetGameStartConfig()
		{
			return LoadObjectFromJSON.LoadFromResources<Game>(Path.Combine(configsFolder, startGameConfigPath));
		}		
		
		public ShopItemList GetShopListConfig()
		{
			return LoadObjectFromJSON.LoadFromResources<ShopItemList>(Path.Combine(configsFolder, shopListConfigPath));
		}		
		
		public ListNaturalResources GetListNaturalResourcesConfig()
		{
			return LoadObjectFromJSON.LoadFromResources<ListNaturalResources>(Path.Combine(configsFolder,
				resourcesListConfigPath));
		}		
		
		public ConsumableFarmItemList GetFarmtemsConfig()
		{
			return LoadObjectFromJSON.LoadFromResources<ConsumableFarmItemList>(Path.Combine(configsFolder, 
				farmItemListConfigPath));
		}
	}
}
