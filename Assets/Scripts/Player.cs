using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IDamageable
{
    #region Movement
    [Header("Movement")]
    [SerializeField] float m_MoveSpeed = 5;

    CharacterController m_Controller;
    Vector3 m_MoveInput;
    #endregion

    #region Damageable
    [Header("Damageable")]
    [SerializeField] int m_Life = 100;
    [SerializeField] float damageCooldown = 1;

    float damageTime;
    public event Action<int> OnTakeDamage;
    public int Life { get => m_Life; set => m_Life = value; }
    #endregion

    #region Shooting
    [Header("Shooting")]
    [SerializeField] GameObject projectile;
    [SerializeField] float cooldown;
    
    Transform target;
    float shootTime;
    #endregion

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

    private void OnMove(InputValue value)
    {
        Vector2 vector = value.Get<Vector2>();
        m_MoveInput.x = vector.x;
        m_MoveInput.z = vector.y;
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

    public int TakeDamage(int damage)
    {
        OnTakeDamage?.Invoke(damage);

        if (Time.time > damageTime)
        {
            Life -= damage;
            damageTime = Time.time + damageCooldown;
        }
        return Life;
    }
}
