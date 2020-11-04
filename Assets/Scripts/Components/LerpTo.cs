using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTo : MonoBehaviour
{
    public Transform target;
    public float speed;

    public Vector3 offset;
    public bool lockX, lockY, lockZ;

    private void LateUpdate()
    {
        if (target == null)
            return;

        var position = Vector3.Lerp(transform.position, target.position + offset, speed * Time.deltaTime);
        
        transform.position = new Vector3 {
            x = lockX ? transform.position.x : position.x,
            y = lockY ? transform.position.y : position.y,
            z = lockZ ? transform.position.z : position.z
        };
    }
}
