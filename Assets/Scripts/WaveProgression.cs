using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveProgression : MonoBehaviour
{
    [SerializeField] SpawnArea spawnArea;
    [SerializeField] Text waveCounter;

    int wave;

    // Formulas
    float StartDelay => 1;
    int TotalSpawns => 8 + wave * 2;
    float SpawnCooldown => Mathf.Max(.1f, .25f - wave * .01f);
    int BurstLimit => Mathf.CeilToInt((float)TotalSpawns / 3);

    #region Event Setup
    private void OnEnable() => PowerUpOption.OnClicked += PowerUpOption_OnClicked;
    private void OnDisable() => PowerUpOption.OnClicked -= PowerUpOption_OnClicked;
    #endregion

    private void Start()
    {
        PowerUpOption_OnClicked(null);
    }

    private void PowerUpOption_OnClicked(PowerUpOption powerUpOption)
    {
        wave++;
        waveCounter.text = string.Format("Wave {0}", wave);
        spawnArea.StartSpawn(StartDelay, TotalSpawns, SpawnCooldown, BurstLimit);
    }
}
