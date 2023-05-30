using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Status", menuName = "SO/StatusSO")]
public class StatusParametersSO : ScriptableObject
{
    #region GetProperties

    public string StatusName => _statusName;
    public int TicksDuration => _ticksDuration;
    public float TicksInterval => _ticksInterval;
    public float DamageScale => _damageScale;

    #endregion

    [SerializeField] private string _statusName = "None";
    [SerializeField] private int _ticksDuration = 1;
    [SerializeField] private float _ticksInterval = 1f;
    [SerializeField] private float _damageScale = 1f;
}