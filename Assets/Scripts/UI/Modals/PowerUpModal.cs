using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpModal : MonoBehaviour
{
    [SerializeField] GameObject content;
    
    private void OnEnable() => SpawnArea.OnSpawnFinish += SpawnArea_OnSpawnFinish;
    private void OnDisable() => SpawnArea.OnSpawnFinish += SpawnArea_OnSpawnFinish;

    private void SpawnArea_OnSpawnFinish(SpawnArea spawnArea) => content.SetActive(true);
}
