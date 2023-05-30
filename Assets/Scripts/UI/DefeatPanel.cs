using DefaultNamespace;
using TMPro;
using UI.MainMenu;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefeatPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _menuButton;
    
    private void OnEnable()
    {
        Time.timeScale = 0;
        
        _restartButton.onClick.AddListener(RestartGame);
        _menuButton.onClick.AddListener(GoToMainMenu);
    }

    private void OnDisable()
    {
        Time.timeScale = 1;

        _restartButton.onClick.RemoveListener(RestartGame);
        _menuButton.onClick.RemoveListener(GoToMainMenu);
    }

    public void UpdateScoreText(Score score)
    {
        _scoreText.text = score.ToString();
    }
    
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    private void GoToMainMenu()
    {
        SceneManager.LoadScene(MainMenuFragment.SceneName);
    }
}
