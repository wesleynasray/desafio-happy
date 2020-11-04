using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] LayerMask damageableMask;
    [SerializeField] bool destroyOnHit;

    private void OnTriggerEnter(Collider other) => DoDamage(other.gameObject);
    private void OnCollisionEnter(Collision collision) => DoDamage(collision.gameObject);

    private void DoDamage(GameObject target)
    {
        if (damageableMask.Includes(target.layer))
        {
            Damageable damageable;
            if (target.TryGetComponent(out damageable))
                damageable.TakeDamage(damage);

            if (destroyOnHit)
                Destroy(gameObject);
        }
    }
}
