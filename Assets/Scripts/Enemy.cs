﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public static List<Enemy> Enemies = new List<Enemy>();
    public static event Action<Enemy> OnEnemyDamaged;

    [SerializeField] int life = 1;

    public int TakeDamage(int damage)
    {
        life = Mathf.Max(0, life - damage);

        if (life == 0)
            Destroy(gameObject);

        OnEnemyDamaged?.Invoke(this);

        return life;
    }

    private void OnEnable()
    {
        Enemies.Add(this);
    }

    private void OnDisable()
    {
        Enemies.Remove(this);
    }
}
