using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float m_MoveSpeed = 5;

    CharacterController m_Controller;
    Vector3 m_MoveInput;

    Transform target;

    private void Awake()
    {
        m_Controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        TargetClosestEnemy();
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

        target = closestEnemy.transform;
    }

    private void Move()
    {
        m_Controller.Move(m_MoveInput.normalized * m_MoveSpeed * Time.deltaTime);
    }

    private void OnMove(InputValue value)
    {
        Vector2 vector = value.Get<Vector2>();
        m_MoveInput.x = vector.x;
        m_MoveInput.z = vector.y;
    }
}
