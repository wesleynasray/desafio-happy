using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreEntry : MonoBehaviour
{
    [SerializeField] Text nameLabel;
    [SerializeField] Text scoreLabel;

    public string Player { get => nameLabel.text; set => nameLabel.text = value; }
    public string Score { get => scoreLabel.text; set => scoreLabel.text = value; }
}
