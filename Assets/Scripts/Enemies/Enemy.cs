using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public static List<Enemy> Enemies = new List<Enemy>();
    public static event Action<Enemy> OnEnemyDamaged;

    [SerializeField] int m_Life = 1;
    public int Life { get => m_Life; set => m_Life = value; }
    public event Action<int> OnTakeDamage;

    protected CharacterController controller;

    protected virtual void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable() => Enemies.Add(this);
    private void OnDisable() => Enemies.Remove(this);

    public int TakeDamage(int damage)
    {
        m_Life = Mathf.Max(0, m_Life - damage);

        if (m_Life == 0)
            Destroy(gameObject);

        OnEnemyDamaged?.Invoke(this);

        return m_Life;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var damageable = hit.gameObject.GetComponent<IDamageable>();
        
        if (damageable != null) 
            damageable.TakeDamage(1);
    }
}
