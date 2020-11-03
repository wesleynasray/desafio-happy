using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveBar : MonoBehaviour
{
    [SerializeField] Image fill;

    float fillMax;
    float fillAmount;

    #region Event Setup
    private void OnEnable()
    {
        SpawnArea.OnSpawnStart += OnSpawnStart;
        SpawnArea.OnSpawnedRemoved += OnSpawnedRemoved;
    }

    private void OnDisable()
    {
        SpawnArea.OnSpawnStart -= OnSpawnStart;
        SpawnArea.OnSpawnedRemoved -= OnSpawnedRemoved;
    }
    #endregion

    private void OnSpawnStart(SpawnArea spawnArea)
    {
        fillMax = spawnArea.TotalSpawns;
        fillAmount = fillMax;
        UpdateFill();
    }

    private void OnSpawnedRemoved(SpawnArea spawnArea, int removeCount)
    {
        fillAmount -= removeCount;
        UpdateFill();
    }

    private void UpdateFill()
    {
        fill.fillAmount = fillAmount / fillMax;
    }
}
