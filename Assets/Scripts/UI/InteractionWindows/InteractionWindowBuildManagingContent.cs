using System;
using Buildings;
using Data;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

namespace UI
{
    public class InteractionWindowBuildManagingContent : InteractionWindowContent
    {
        [SerializeField] private GameParametersSO _gameParametersSo;

        [SerializeField] private BuildingsManager _buildingsManager;
        [SerializeField] private WalletManager _walletManager;

        [SerializeField] private Button _sellBuildingButton;
        [SerializeField] private TextMeshProUGUI _cashbackText;

        private int cashback;

        public void Awake()
        {
            cashback = 0;
            _sellBuildingButton.onClick.AddListener(HandleOnSellButtonClicked);
        }

        public void OnEnable()
        {
            var cost = _buildingsManager.GetBuildingCost(
                currentCell.BuildingType,
                currentCell.Building.ElementType
            );
            cashback = CalculateCashback(cost);
            _cashbackText.text = cashback.ToString();
        }

        private void HandleOnSellButtonClicked()
        {
            _walletManager.DepositMoney(cashback);
            _buildingsManager.Destroy(currentCell);
            EventManager.InvokeOnInteractionWindowHideRequested();
        }


        private int CalculateCashback(int originalCost)
        {
            return (int)(originalCost * _gameParametersSo.CashbackСoefficient);
        }
    }
}