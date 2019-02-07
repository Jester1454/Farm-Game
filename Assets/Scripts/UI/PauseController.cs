using GameController;
using Saves;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
	public class PauseController : MonoBehaviour
	{
		[SerializeField] private Button _pauseButton;
		[SerializeField] private Button _loadButton;
		[SerializeField] private Button _resumeButton;
		[SerializeField] private Button _saveButton;
		[SerializeField] private Button _quitButton;
		[SerializeField] private GameObject _pausePanel;

		private bool _isPause = false;
		private SavesController _savesController;
		
		private void Awake()
		{
			Resume();
			_savesController = new SavesController();;
			_pauseButton.onClick.AddListener(OnPause);
			_resumeButton.onClick.AddListener(Resume);
			_loadButton.onClick.AddListener(Load);
			_saveButton.onClick.AddListener(Save);
			_quitButton.onClick.AddListener(Quit);
		}

		private void Quit()
		{
			Save();
			Application.Quit();
		}

		private void Save()
		{
			_savesController.Save(FarmingGameController.CurrentGame);
			Resume();
		}

		private void Load()
		{
			Scene scene = SceneManager.GetActiveScene(); 
			SceneManager.LoadScene(scene.name);
		}

		private void OnPause()
		{
			_pausePanel.SetActive(true);
			_isPause = true;
			Time.timeScale = 0;
		}

		private void Resume()
		{
			_pausePanel.SetActive(false);
			_isPause = false;
			Time.timeScale = 1;
		}
	}
}
