using System.IO;
using Config;
using GameController;
using UnityEngine;
using Utilities;

namespace Saves
{
	public class SavesController 
	{
		public Game Load()
		{
			string	gameSavePath = Path.Combine(Application.persistentDataPath, "game.json");
			
			ConfigController configController = new ConfigController();
			Game startGame = configController.GetGameStartConfig();

			Game loadGame = LoadObjectFromJSON.Load<Game>(gameSavePath);
			
			if (loadGame != null)
			{
				return loadGame;
			}

			return startGame;
		}

		public void Save(Game game)
		{
			string	gameSavePath = Path.Combine(Application.persistentDataPath, "game.json");
			
			SaveObjectInJSON.Save(gameSavePath, game);
		}
	}
}
