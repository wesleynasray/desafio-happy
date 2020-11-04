using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : Enemy
{
    [SerializeField] LookTowards look;

    private void Start()
    {
        look.target = FindObjectOfType<Player>().transform;
    }
}
