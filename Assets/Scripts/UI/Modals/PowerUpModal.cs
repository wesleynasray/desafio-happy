using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpModal : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] PowerUpOption[] options;
    [SerializeField] PowerUpBase[] possiblePowers;
    [Space]
    [SerializeField] Player player;

    #region Event Listening
    private void OnEnable()
    {
        SpawnArea.OnSpawnFinish += SpawnArea_OnSpawnFinish;
        PowerUpOption.OnClicked += PowerUpOption_OnClicked;
    }
    private void OnDisable()
    {
        SpawnArea.OnSpawnFinish -= SpawnArea_OnSpawnFinish;
        PowerUpOption.OnClicked -= PowerUpOption_OnClicked;
    }
    #endregion

    private void SpawnArea_OnSpawnFinish(SpawnArea spawnArea)
    {
        SetupOptions();
        content.SetActive(true);
    }

    private void PowerUpOption_OnClicked(PowerUpOption power)
    {
        if(power != null) 
            player.AddPowerUp(power.PowerUp);
    }

    private void SetupOptions()
    {
        List<PowerUpBase> availablePowers = new List<PowerUpBase>(possiblePowers);

        foreach (var option in options)
        {
            if (availablePowers.Count == 0)
                break;

            var random = Random.Range(0, availablePowers.Count);
            option.PowerUp = availablePowers[random];
            availablePowers.RemoveAt(random);
        }
    }
}
