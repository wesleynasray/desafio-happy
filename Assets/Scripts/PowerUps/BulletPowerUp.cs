using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletPowerUp", menuName = "ScriptableObjects/BulletPowerUp")]
public class BulletPowerUp : PowerUpBase
{
    [Header("Bullet")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] BulletSetup[] bulletSetups;

    [System.Serializable]
    public struct BulletSetup
    {
        public Vector3 direction;
        public Vector3 offset;
    }

    public override void Action(GameObject caller)
    {
        foreach(var setup in bulletSetups)
        {
            Instantiate(
                bulletPrefab,
                caller.transform.position + setup.offset, 
                Quaternion.LookRotation(caller.transform.TransformDirection(setup.direction.normalized))
            );
        }
    }
}
