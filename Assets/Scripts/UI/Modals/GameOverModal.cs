using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverModal : MonoBehaviour
{
    [SerializeField] Damageable player;
    [Space]
    [SerializeField] GameObject content;
    [SerializeField] Text scoreCounter;
    
    private void OnEnable() => player.OnDeath += Player_OnDeath;
    private void OnDisable() => player.OnDeath -= Player_OnDeath;

    private void Player_OnDeath()
    {
        scoreCounter.text = Score.Amount.ToString();
        content.SetActive(true);
    }

    public void PlayAgainClicked()
    {
        // TODO: send highscore
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
