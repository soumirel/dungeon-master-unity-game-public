using System;
using UnityEngine;

public class Wallet
{
    private int _value;
    private int _minValue;

    public Wallet(int startValue, int minValue = 0)
    {
        _value = startValue;
        _minValue = minValue;
    }

    public int Value
    {
        get => _value;
        set => _value = Mathf.Max(value, _minValue);
    }
}