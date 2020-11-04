using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static List<Enemy> Enemies = new List<Enemy>();
    public static event Action<Enemy> OnEnemyDamaged;

    protected CharacterController controller;

    protected virtual void Awake()
    {
        controller = GetComponent<CharacterController>();

        Damageable damageable;
        if(TryGetComponent(out damageable))
            damageable.OnTakeDamage += d => OnEnemyDamaged?.Invoke(this);
    }

    private void OnEnable() => Enemies.Add(this);
    private void OnDisable() => Enemies.Remove(this);
}
