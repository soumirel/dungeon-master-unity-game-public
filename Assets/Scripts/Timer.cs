using System;
using UnityEngine;

public class Timer
{
    private readonly Action _handler;
        
    private float _intervalInSeconds;
    private float _lastTickTime;

    public float IntervalInSeconds
    {
        set => _intervalInSeconds = value;
    }

    public Timer(Action handler, float intervalInSeconds)
    {
        _handler = handler;
        _intervalInSeconds = intervalInSeconds;
    }
        
    public void Tick()
    {
        if (Time.time - _lastTickTime > _intervalInSeconds)
        {
            _handler();
            _lastTickTime = Time.time;
        }
    }
}