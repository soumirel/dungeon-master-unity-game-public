using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu
{
    public class CreditsFragment : MonoBehaviour
    {
        [SerializeField] private MainMenuFragment _mainMenuFragment;
        [SerializeField] private Button _backButton;

        [SerializeField] private ScrollRect _scrollRect;

        public void Awake()
        {
            _backButton.onClick.AddListener(BackToMainFragment);
        }

        public void OnEnable()
        {
            _scrollRect.normalizedPosition = new Vector2(_scrollRect.normalizedPosition.x, 0);
        }

        public void BackToMainFragment()
        {
            _mainMenuFragment.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}