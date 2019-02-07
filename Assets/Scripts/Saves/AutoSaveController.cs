using System.Collections;
using GameController;
using UnityEngine;

namespace Saves
{
	public class AutoSaveController : MonoBehaviour
	{

		[SerializeField] private float _autoSaveTimeCycle;
		private SavesController _savesController;
		private void Awake()
		{
			_savesController = new SavesController();
			StartCoroutine(AutoSaveCycle());
		}

		IEnumerator AutoSaveCycle()
		{
			WaitForSeconds autoSaveDelay = new WaitForSeconds(_autoSaveTimeCycle);

			while (true)
			{
				yield return autoSaveDelay;
				_savesController.Save(FarmingGameController.CurrentGame);
			}
		}
	}
}
