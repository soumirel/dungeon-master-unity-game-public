using UnityEngine;

public class Health
{
    private float _value;
    private float _minValue;
    private float _maxValue;

    public Health(float maxValue, float minValue = 0)
    {
        _minValue = Mathf.Min(minValue, maxValue);
        _maxValue = Mathf.Max(minValue, maxValue);
        
        _value = _maxValue;
    }

    public float Value
    {
        set => _value = Mathf.Clamp(value, _minValue, _maxValue);
        get => _value;
    }

    public float MinValue
    {
        set => _minValue = Mathf.Min(value, _maxValue);
        get => _minValue;
    }
    
    public float MaxValue
    {
        set => _maxValue = Mathf.Max(value, _minValue);
        get => _maxValue;
    }

    public float AbsoluteValue => _value / _maxValue;

    public void Reset()
    {
        _value = _maxValue;
    }
}