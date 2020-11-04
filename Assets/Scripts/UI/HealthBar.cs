using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image fill;
    [SerializeField] Damageable target;

    int originalLife;

    private void Awake()
    {
        originalLife = target.Life;
        target.OnTakeDamage += Target_OnTakeDamage;
    }

    private void Target_OnTakeDamage(int damage)
    {
        fill.fillAmount = (float)target.Life / originalLife;
    }
}
