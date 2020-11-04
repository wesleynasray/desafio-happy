using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public event Action<int> OnTakeDamage;
    public event Action OnDeath;

    public int Life => m_life;

    [SerializeField] int m_life;
    [SerializeField] float damageCooldown;
    [SerializeField] float destroyDelay;

    float damageTime;

    public void TakeDamage(int damage) {
        if (damage == 0)
            return;
        
        if(Time.time > damageTime)
        {
            m_life = Mathf.Max(0, m_life - damage);
            OnTakeDamage?.Invoke(damage);

            damageTime = Time.time + damageCooldown;

            if (m_life <= 0)
            {
                OnDeath?.Invoke();
                Destroy(gameObject, destroyDelay);
            }
        }
    }
}
