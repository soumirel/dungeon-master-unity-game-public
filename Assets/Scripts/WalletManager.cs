using Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;


public class WalletManager : MonoBehaviour
{
    public readonly UnityEvent<int> OnMoneyChanged =
        new UnityEvent<int>();
    
    [SerializeField] private GameParametersSO _gameParametersSo;

    private Wallet _wallet;

    public void Awake()
    {
        InitializeWallet();
    }

    private void InitializeWallet()
    {
        _wallet = new Wallet(_gameParametersSo.StartMoney);
        OnMoneyChanged?.Invoke(_wallet.Value);
    }

    public int MoneyAmount => _wallet.Value;

    public bool TryWithdrawMoney(int amount)
    {
        if (_wallet.Value < amount)
        {
            return false;
        }

        _wallet.Value -= amount;
        OnMoneyChanged?.Invoke(_wallet.Value);
        return true;
    }

    public void DepositMoney(int amount)
    {
        _wallet.Value += amount;
        OnMoneyChanged?.Invoke(_wallet.Value);
    }
}