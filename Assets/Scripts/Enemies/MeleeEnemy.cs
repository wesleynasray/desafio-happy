using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] float speed;
    Transform target;

    float startMoveDelay;

    protected void Start()
    {
        startMoveDelay = Time.time + 1;
        target = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        if (Time.time < startMoveDelay)
            return;

        var direction = (target.position - transform.position).normalized;
        direction.y = 0;

        controller.Move(direction * speed * Time.deltaTime);
    }
}
