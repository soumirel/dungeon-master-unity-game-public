using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PausePanelOpener : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private PausePanel _pausePanel;

        [SerializeField] private GameMusic _gameMusic;
        
        private void OnEnable()
        {
            _pauseButton.onClick.AddListener(Open);
        }

        private void OnDisable()
        {
            _pauseButton.onClick.RemoveListener(Open);
        }

        private void Open()
        {
            Time.timeScale = 0;
            _gameMusic.StopMusic();
            _pausePanel.gameObject.SetActive(true);
        }
    }
}