using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnArea : MonoBehaviour
{
    public static event Action<SpawnArea> OnSpawnStart;
    public static event Action<SpawnArea, int> OnSpawnedRemoved;
    public static event Action<SpawnArea> OnSpawnFinish;

    [SerializeField] Vector3 extent = Vector3.one * 5;
    [SerializeField] GameObject[] toSpawn;
    [SerializeField] float startDelay;
    [SerializeField] int totalSpawns;
    [SerializeField] float spawnCooldown;
    [SerializeField] int burstLimit;

    List<GameObject> spawnedList = new List<GameObject>();

    public int TotalSpawns { get => totalSpawns; }

    public void StartSpawn(float startDelay, int totalSpawns, float spawnCooldown, int burstLimit)
    {
        this.startDelay = startDelay;
        this.totalSpawns = totalSpawns;
        this.spawnCooldown = spawnCooldown;
        this.burstLimit = burstLimit;

        StartCoroutine(SpawnRoutine());
    }
    private IEnumerator SpawnRoutine()
    {
        // Start Event and Delay
        OnSpawnStart?.Invoke(this);
        yield return new WaitForSeconds(startDelay);

        // Delays Setup
        var cooldown = new WaitForSeconds(spawnCooldown);
        
        var waitCountZero = new WaitUntil(() => { 
            var removeCount = spawnedList.RemoveAll(s => s == null);
            
            if(removeCount > 0)
                OnSpawnedRemoved?.Invoke(this, removeCount);

            return spawnedList.Count == 0; 
        });

        // Spawning process
        for(int spawns = 0; spawns < totalSpawns; spawns++)
        {
            var random = toSpawn[Random.Range(0, toSpawn.Length)];
            
            var spawned = Instantiate(random, transform);
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

        // Finish Event
        yield return waitCountZero;
        OnSpawnFinish?.Invoke(this);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, extent);
    }
}
