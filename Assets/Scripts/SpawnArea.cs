using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    [SerializeField] Vector3 extent = Vector3.one * 5;
    [SerializeField] GameObject toSpawn;
    [SerializeField] float cooldown;
    [SerializeField] float intialDelay;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(intialDelay);
        var wait = new WaitForSeconds(cooldown);

        while (enabled)
        {
            var spawn = Instantiate(toSpawn, transform);
            spawn.transform.position = new Vector3
            {
                x = transform.position.x + Random.Range(-extent.x, extent.x) * .5f,
                y = transform.position.y + Random.Range(-extent.y, extent.y) * .5f,
                z = transform.position.z + Random.Range(-extent.z, extent.z) * .5f
            };
            yield return wait;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, extent);
    }
}
