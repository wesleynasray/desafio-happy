using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreModal : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] Transform entriesParent;
    [SerializeField] HighScoreEntry entryPrefab;

    private void Start()
    {
        content.SetActive(true);
        Network.GetScores(OnGetScores);
    }

    private void OnGetScores(Network.ScoreEntry[] scores)
    {
        foreach (var score in scores)
        {
            var entry = Instantiate(entryPrefab, entriesParent);
            
            entry.Player = score.name;
            entry.Score = score.score.ToString();
        }
    }
}
