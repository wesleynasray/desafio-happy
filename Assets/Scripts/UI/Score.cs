using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int Amount { get; private set; }

    [SerializeField] Text label;

    private void OnEnable() => Enemy.OnEnemyDamaged += Enemy_OnEnemyDamaged;
    private void OnDisable() => Enemy.OnEnemyDamaged -= Enemy_OnEnemyDamaged;

    private void Awake()
    {
        Amount = 0;
        Enemy_OnEnemyDamaged(null);
    }

    private void Enemy_OnEnemyDamaged(Enemy enemy)
    {
        Amount += 1;
        label.text = $"Score: {Amount}";
    }
}
