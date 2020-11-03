using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    [SerializeField] Vector3 extent = Vector3.one * 5;
    [SerializeField] GameObject toSpawn;
    [SerializeField] float startDelay;
    [SerializeField] int totalSpawns;
    [SerializeField] float spawnCooldown;
    [SerializeField] int burstLimit;

    [SerializeField] List<GameObject> spawnedList = new List<GameObject>();

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(startDelay);
        
        var cooldown = new WaitForSeconds(spawnCooldown);
        var waitCountZero = new WaitUntil(() => { spawnedList.RemoveAll(s => s == null); return spawnedList.Count == 0; });

        for(int spawns = 0; spawns < totalSpawns; spawns++)
        {
            var spawned = Instantiate(toSpawn, transform);
            spawned.transform.position = new Vector3
            {
                x = transform.position.x + Random.Range(-extent.x, extent.x) * .5f,
                y = transform.position.y + Random.Range(-extent.y, extent.y) * .5f,
                z = transform.position.z + Random.Range(-extent.z, extent.z) * .5f
            };
            spawnedList.Add(spawned);

            if(spawnedList.Count >= burstLimit)
                yield return waitCountZero;

            yield return cooldown;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, extent);
    }
}
