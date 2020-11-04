﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IDamageable
{
    [Header("Movement")]
    [SerializeField] float m_MoveSpeed = 5;
    
    CharacterController m_Controller;
    Vector3 m_MoveInput;
    
    [Header("Damageable")]
    [SerializeField] int life = 100;
    [SerializeField] float damageCooldown = 1;

    float damageTime;

    [Header("Shooting")]
    [SerializeField] GameObject projectile;
    [SerializeField] float cooldown;
    
    Transform target;
    float shootTime;

    private void Awake()
    {
        m_Controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        TargetClosestEnemy();
        
        if(m_MoveInput.sqrMagnitude == 0)
            Shoot();
    }

    private void Move()
    {
        m_Controller.Move(m_MoveInput.normalized * m_MoveSpeed * Time.deltaTime);
    }

    private void TargetClosestEnemy()
    {
        Enemy closestEnemy = null;
        float closestSqrDistance = float.PositiveInfinity;

        foreach (var enemy in Enemy.Enemies)
        {
            var sqrDistance = Vector3.SqrMagnitude(enemy.transform.position - transform.position);
            if (sqrDistance < closestSqrDistance)
            {
                closestSqrDistance = sqrDistance;
                closestEnemy = enemy;
            }
        }

        target = closestEnemy != null ? closestEnemy.transform : null;
    }

    private void Shoot()
    {
        if (target == null)
            return;

        if(Time.time > shootTime)
        {
            var direction = Quaternion.LookRotation(target.position - transform.position);
            Instantiate(projectile, transform.position, direction);
            shootTime = Time.time + cooldown;
        }
    }

    private void OnMove(InputValue value)
    {
        Vector2 vector = value.Get<Vector2>();
        m_MoveInput.x = vector.x;
        m_MoveInput.z = vector.y;
    }

    public int TakeDamage(int damage)
    {
        if (Time.time > damageTime)
        {
            life -= damage;
            damageTime = Time.time + damageCooldown;
        }
        return life;
    }
}
