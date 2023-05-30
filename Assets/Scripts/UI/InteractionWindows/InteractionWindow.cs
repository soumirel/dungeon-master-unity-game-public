using System;
using System.Linq;
using Buildings;
using Elements;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class InteractionWindow : MonoBehaviour
    {
        [SerializeField] private InteractionWindowBuildingContent _buildingContent;
        [SerializeField] private InteractionWindowBuildManagingContent _buildManagingContent;

        [SerializeField] private GameObject _background;
        [SerializeField] private Button _hideButton;
        
        private InteractionWindowContent _currentContent;

        public void Start()
        {
            EventManager.OnCellClicked.AddListener(HandleOnCellClicked);
            EventManager.OnInteractionWindowHideRequested.AddListener(Hide);
            _hideButton.onClick.AddListener(Hide);
        }

        private void HandleOnCellClicked(FieldCell cell)
        {
            if (_currentContent != null)
            {
                Hide();
            }
            
            _background.gameObject.SetActive(true);
            
            if (cell.isEmpty())
            {
                _currentContent = _buildingContent;
            }
            else
            {
                _currentContent = _buildManagingContent;
            }
            
            _currentContent.CurrentCell = cell;
            _currentContent.gameObject.SetActive(true);
        }


        private void Hide()
        {
            _currentContent.gameObject.SetActive(false);
            _currentContent = null;
            _background.gameObject.SetActive(false);
        }
    }




}