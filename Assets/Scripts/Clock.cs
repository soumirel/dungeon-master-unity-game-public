using System;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private float _elapsedTime;
    [SerializeField] private TextMeshProUGUI _secondsTMP;
    [SerializeField] private TextMeshProUGUI _minutesTMP;

    public int Seconds { get; private set; }
    public int Minutes { get; private set; }
    
    public void Start()
    {
        _elapsedTime = 0;
    }

    public void Update()
    {
        _elapsedTime += Time.deltaTime;
        
        Seconds = (int)_elapsedTime % 60;
        Minutes = (int)_elapsedTime / 60;
        
        _secondsTMP.text = Seconds.ToString().PadLeft(2, '0');
        _minutesTMP.text = Minutes.ToString().PadLeft(2, '0');
    }
}