using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.MainMenu
{
    public class MainMenuFragment : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
    
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _creditsButton;
        [SerializeField] private Button _exitButton;

        [SerializeField] private CreditsFragment _creditsFragment;

        public const string SceneName = "MainMenuScene";
        private const string GameSceneName = "GameScene";
    
        private void Start()
        {
            TryShowBestScoreText();

            _playButton.onClick.AddListener(GoToGameScene);
            _creditsButton.onClick.AddListener(OpenCreditsPanel);
            _exitButton.onClick.AddListener(Exit);
        }

        private void OnDestroy()
        {
            _playButton.onClick.RemoveListener(GoToGameScene);
            _creditsButton.onClick.RemoveListener(OpenCreditsPanel);
            _exitButton.onClick.RemoveListener(Exit);
        }

        private void GoToGameScene()
        {
            SceneManager.LoadScene(GameSceneName);
        }

        private void OpenCreditsPanel()
        {
            _creditsFragment.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    
        private void Exit()
        {
            Application.Quit();
        }

        private void TryShowBestScoreText()
        {
            _scoreText.enabled = ScoreSaver.HasBestScore();
        
            if (_scoreText.enabled)
            {
                Score score = ScoreSaver.LoadBestScore();
                _scoreText.text = score.ToString();
            }
        }
    }
}
