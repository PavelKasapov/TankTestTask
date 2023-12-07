using System;
using UnityEngine;
using Zenject;

public class HitTaker : MonoBehaviour
{
    [Inject] private HpSystem hpSystem;
    public void TakeDamage(float damageValue)
    {
        hpSystem.TakeDamage(damageValue);
    }
}