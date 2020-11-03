using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveProgression : MonoBehaviour
{
    [SerializeField] SpawnArea spawnArea;
    [SerializeField] Text waveCounter;

    int wave;

    float StartDelay => 1;
    int TotalSpawns => 8 + wave * 2;
    float SpawnCooldown => Mathf.Max(.1f, .25f - wave * .01f);
    int BurstLimit => Mathf.CeilToInt((float)TotalSpawns / 3);

    #region Event Setup
    private void OnEnable()
    {
        SpawnArea.OnSpawnFinish += SpawnArea_OnSpawnFinish;
    }

    private void OnDisable()
    {
        SpawnArea.OnSpawnFinish -= SpawnArea_OnSpawnFinish;
    }
    #endregion

    private void Start()
    {
        SpawnArea_OnSpawnFinish(spawnArea);
    }

    private void SpawnArea_OnSpawnFinish(SpawnArea spawnArea)
    {
        if(spawnArea == this.spawnArea)
        {
            wave++;
            waveCounter.text = string.Format("Wave {0}", wave);
            spawnArea.StartSpawn(StartDelay, TotalSpawns, SpawnCooldown, BurstLimit);
        }
    }
}
