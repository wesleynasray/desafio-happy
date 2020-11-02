using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static List<Enemy> Enemies = new List<Enemy>();

    private void OnEnable()
    {
        Enemies.Add(this);
    }

    private void OnDisable()
    {
        Enemies.Remove(this);
    }
}
