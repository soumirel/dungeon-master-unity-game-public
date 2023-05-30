using System;
using System.Linq;
using Buildings;
using Elements;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InteractionWindowBuildingContent : InteractionWindowContent
    {
        [SerializeField] private BuildingsManager _buildingsManager;
        [SerializeField] private WalletManager _walletManager;

        private class ButtonWrapper
        {
            public static Action<ButtonWrapper> OnButtonClicked;

            private BuildingType _buildingType;
            private ElementType _elementType;

            private Button _button;

            public BuildingType BuildingType => _buildingType;
            public ElementType ElementType => _elementType;

            public ButtonWrapper(BuildingType buildingType, ElementType elementType, Button button)
            {
                _buildingType = buildingType;
                _elementType = elementType;
                _button = button;

                _button.onClick.AddListener(HandleOnButtonClicked);
            }

            private void HandleOnButtonClicked()
            {
                OnButtonClicked?.Invoke(this);
            }
        }

        [SerializeField] private Button[] _buildTowerButtons;
        [SerializeField] private Button[] _buildLensButtons;

        [SerializeField] private TextMeshProUGUI[] _towersCosts;
        [SerializeField] private TextMeshProUGUI[] _lensCosts;

        private ButtonWrapper[] _buttonWrappers;

        public void Awake()
        {
            InitializeButtonWrappers();
            InitializeCost();
        }

        public void Start()
        {
            ButtonWrapper.OnButtonClicked += HandleOnButtonWrapperClicked;
        }

        private void InitializeButtonWrappers()
        {
            _buttonWrappers = new[]
            {
                new ButtonWrapper(BuildingType.Tower, ElementType.Fire, _buildTowerButtons[0]),
                new ButtonWrapper(BuildingType.Tower, ElementType.Water, _buildTowerButtons[1]),
                new ButtonWrapper(BuildingType.Tower, ElementType.Wind, _buildTowerButtons[2]),
                new ButtonWrapper(BuildingType.Tower, ElementType.Earth, _buildTowerButtons[3]),
                new ButtonWrapper(BuildingType.Lens, ElementType.Fire, _buildLensButtons[0]),
                new ButtonWrapper(BuildingType.Lens, ElementType.Water, _buildLensButtons[1]),
                new ButtonWrapper(BuildingType.Lens, ElementType.Wind, _buildLensButtons[2]),
                new ButtonWrapper(BuildingType.Lens, ElementType.Earth, _buildLensButtons[3])
            };
        }

        private void InitializeCost()
        {
            _towersCosts[0].text = _buildingsManager.GetBuildingCost(BuildingType.Tower, ElementType.Fire).ToString();
            _towersCosts[1].text = _buildingsManager.GetBuildingCost(BuildingType.Tower, ElementType.Water).ToString();
            _towersCosts[2].text = _buildingsManager.GetBuildingCost(BuildingType.Tower, ElementType.Wind).ToString();
            _towersCosts[3].text = _buildingsManager.GetBuildingCost(BuildingType.Tower, ElementType.Earth).ToString();
            
            _lensCosts[0].text = _buildingsManager.GetBuildingCost(BuildingType.Lens, ElementType.Fire).ToString();
            _lensCosts[1].text = _buildingsManager.GetBuildingCost(BuildingType.Lens, ElementType.Water).ToString();
            _lensCosts[2].text = _buildingsManager.GetBuildingCost(BuildingType.Lens, ElementType.Wind).ToString();
            _lensCosts[3].text = _buildingsManager.GetBuildingCost(BuildingType.Lens, ElementType.Earth).ToString();
        }

        private void HandleOnButtonWrapperClicked(ButtonWrapper buttonWrapper)
        {
            var cost = _buildingsManager.GetBuildingCost(buttonWrapper.BuildingType, buttonWrapper.ElementType);
            if (_walletManager.TryWithdrawMoney(cost))
            {
                currentCell.SetBuilding(
                    _buildingsManager.Build(currentCell, buttonWrapper.BuildingType, buttonWrapper.ElementType),
                    buttonWrapper.BuildingType);
                EventManager.InvokeOnInteractionWindowHideRequested();
            }
        }
    }
}