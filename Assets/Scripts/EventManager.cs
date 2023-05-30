using Buildings;
using Elements;
using UI;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static readonly UnityEvent<FieldCell> OnCellClicked =
        new UnityEvent<FieldCell>();

    public static readonly UnityEvent<int> OnMoneyChanged =
        new UnityEvent<int>();

    public static readonly UnityEvent OnInteractionWindowHideRequested =
        new UnityEvent();

    public static readonly UnityEvent<int> OnEnemyDied =
        new UnityEvent<int>();

    public static void InvokeOnCellClicked(FieldCell cell)
    {
        OnCellClicked?.Invoke(cell);
    }

    public static void InvokeOnMoneyChanged(int money)
    {
        OnMoneyChanged?.Invoke(money);
    }

    public static void InvokeOnInteractionWindowHideRequested()
    {
        OnInteractionWindowHideRequested?.Invoke();
    }

    public static void InvokeOnEnemyDied(int reward)
    {
        OnEnemyDied?.Invoke(reward);
    }
}
