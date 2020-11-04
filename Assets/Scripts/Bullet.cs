using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage;
    [SerializeField] LayerMask collisionMask;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collisionMask.Includes(other.gameObject.layer))
        {
            Damageable damageable;
            if(other.TryGetComponent(out damageable))
                damageable.TakeDamage(damage);
            
            Destroy(gameObject);
        }
    }
}
