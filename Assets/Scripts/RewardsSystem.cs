using System;
using UnityEngine;

public class RewardsSystem : MonoBehaviour
{
    [SerializeField] private WalletManager _walletManager;

    public void Awake()
    {
        EventManager.OnEnemyDied.AddListener(PayReward);
    }

    private void PayReward(int reward)
    {
        _walletManager.DepositMoney(reward);
    }
}