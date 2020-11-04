using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image fill;
    [SerializeField] GameObject target;
    IDamageable damageable;

    int originalLife;

    private void Awake()
    {
        if(target.TryGetComponent(out damageable))
        {
            damageable.OnTakeDamage += Damageable_OnTakeDamage;
            originalLife = damageable.Life;
        }
    }

    private void Damageable_OnTakeDamage(int damage)
    {
        fill.fillAmount = (float)damageable.Life / originalLife;
    }
}
