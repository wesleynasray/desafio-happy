using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Network : MonoBehaviour
{
    #region StaticInstance
    private static Network m_Instance;
    private static Network Instance { 
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<Network>();
                DontDestroyOnLoad(m_Instance.gameObject);
            }
            return m_Instance;
        }
    }
    #endregion

    const string url = "https://desafio-happy.firebaseio.com/scores.json";

    [Serializable]
    public class ScoreList
    {
        public Dictionary<string, ScoreEntry> scores = new Dictionary<string, ScoreEntry> { };
    }
    [Serializable]
    public class ScoreEntry
    {
        public string name;
        public int score;
    }

    public static void PutScore(string name, int score)
    {
        if (string.IsNullOrWhiteSpace(name))
            name = "unknown";

        Instance.StartCoroutine(PutScoreRoutine(new ScoreEntry { name = name, score = score }));
    }
    private static IEnumerator PutScoreRoutine(ScoreEntry score)
    {
        var data = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(score));

        using (var www = new UnityWebRequest()) 
        { 
            www.url = url;
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            www.uploadHandler = new UploadHandlerRaw(data);
            www.downloadHandler = new DownloadHandlerBuffer();
        
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Received: " + www.downloadHandler.text);
            }
        }
    }

    public static void GetScores(Action<ScoreEntry[]> callback)
    {
        Instance.StartCoroutine(GetScoresRoutine(callback));
    }
    private static IEnumerator GetScoresRoutine(Action<ScoreEntry[]> callback)
    {
        using (var www = new UnityWebRequest())
        {
            www.url = url;
            www.method = "GET";
            www.downloadHandler = new DownloadHandlerBuffer();

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Received: " + www.downloadHandler.text);
            }

            var json = JSON.Parse(www.downloadHandler.text);
            List<ScoreEntry> scores = new List<ScoreEntry>();
            
            foreach (var item in json)
            {
                var entry = JsonUtility.FromJson<ScoreEntry>(item.Value);
                scores.Add(new ScoreEntry { name = item.Value["name"], score = item.Value["score"] });
            }

            callback?.Invoke(scores.ToArray());
        }
    }
}
