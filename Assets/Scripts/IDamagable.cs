using System;
using UnityEngine.Events;

public interface IDamagable
{
    void TakeDamage(float damage);

    //TODO: Реализовать ивент
    event Action<float> OnAbsoluteHealthValueChanged;
}

