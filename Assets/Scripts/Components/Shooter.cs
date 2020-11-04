using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] BulletPowerUp[] bulletPowers;
    [SerializeField] float cooldown;

    float shootTime;

    private void Update()
    {
        if(Time.time > shootTime)
        {
            foreach (var power in bulletPowers)
                power.Action(gameObject, bulletPrefab);

            shootTime = Time.time + cooldown;
        }
    }
}
