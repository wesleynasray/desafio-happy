using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    #region Movement
    [Header("Movement")]
    [SerializeField] float m_MoveSpeed = 5;

    CharacterController m_Controller;
    Vector3 m_MoveInput;
    #endregion

    #region Shooting
    [Header("Shooting")]
    [SerializeField] float cooldown;
    
    Transform target;
    float shootTime;
    #endregion

    #region PowerUps
    [Header("Powers")]
    [SerializeField] List<PowerUpBase> powerUps = new List<PowerUpBase>();    
    #endregion

    private void Awake()
    {
        m_Controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        TargetClosestEnemy();
     
        if(m_MoveInput.sqrMagnitude != 0)
            Move();
        else
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
        transform.rotation = Quaternion.LookRotation(m_MoveInput.normalized);
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
            transform.LookAt(target);

            foreach (var power in powerUps)
                power.Action(gameObject);

            shootTime = Time.time + cooldown;
        }
    }

    public void AddPowerUp(PowerUpBase powerUp)
    {
        foreach (var power in powerUp.PowerUpsToOverride)
            powerUps.Remove(power);

        powerUps.Add(powerUp);
    }
}
