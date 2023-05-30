using UI.MainMenu;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class PausePanel : MonoBehaviour
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _menuButton;

        [SerializeField] private GameMusic _gameMusic;

        private void OnEnable()
        {
            _resumeButton.onClick.AddListener(ResumeGame);
            _menuButton.onClick.AddListener(GoToMainMenu);
        }

        private void OnDisable()
        {
            _resumeButton.onClick.RemoveListener(ResumeGame);
            _menuButton.onClick.RemoveListener(GoToMainMenu);
        }

        private void ResumeGame()
        {
            Time.timeScale = 1;
            _gameMusic.ContinueMusic();
            gameObject.SetActive(false);
        }

        private void GoToMainMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(MainMenuFragment.SceneName);
        }
    }
}