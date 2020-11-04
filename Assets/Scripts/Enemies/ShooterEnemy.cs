using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : Enemy
{
    [SerializeField] LookTowards look;
    [SerializeField] Shooter shooter;
    [SerializeField] float startDelay;

    protected override void Awake()
    {
        base.Awake();
        shooter.enabled = false;
    }

    private IEnumerator Start()
    {
        look.target = FindObjectOfType<Player>().transform;
        
        yield return new WaitForSeconds(startDelay);
        shooter.enabled = true;
    }
}
