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
    [SerializeField] InputField nameField;
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
        Network.PutScore(nameField.text, int.Parse(scoreCounter.text));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
