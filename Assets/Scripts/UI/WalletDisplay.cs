using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class WalletDisplay : MonoBehaviour
    {
        [SerializeField] private WalletManager _walletManager;
        [SerializeField] private TextMeshProUGUI _moneyText;

        public void Awake()
        {
            _walletManager.OnMoneyChanged.AddListener(UpdateMoneyText);
        }

        public void Start()
        {
            _moneyText.text = _walletManager.MoneyAmount.ToString();
        }

        private void UpdateMoneyText(int money)
        {
            _moneyText.text = money.ToString();
        }

    }
}