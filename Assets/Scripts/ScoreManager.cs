using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private string _PlayerName;
    private int _BestScore;
    private string _BestScorePlayer;
    private List<Score> _ScoreTable;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScoreTable();
    }

    public void SetPlayerName(string playerName)
    {
        _PlayerName = playerName;
    }

    public string GetPlayerName()
    {
        return _PlayerName;
    }

    public int GetBestScore()
    {
        return _BestScore;
    }

    public string GetBestPlayer()
    {
        return _BestScorePlayer;
    }
    [System.Serializable]
    class Score
    {
        public int BestScore;
        public string BestScorePlayerName;

    }

[System.Serializable]
    class ScoreData
    {
        public List<Score> ScoreTable;
    }

    public void NewHighScore ( int newScore)
    {
        _BestScore = newScore;
        _BestScorePlayer = _PlayerName;
        SaveBestScore();

    }
    private void SaveBestScore()
    {
        Score data = new Score();

        data.BestScore = _BestScore;
        data.BestScorePlayerName = _BestScorePlayer;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/bestscore.json", json);
    }
    private void LoadScoreTable()
    {
        string path = Application.persistentDataPath + "/bestscore.json";
        if (File.Exists(path))
        { 
        string json = File.ReadAllText(path);
            ScoreData data = JsonUtility.FromJson<ScoreData>(json);
            if (data != null)
            {
               
                _ScoreTable = data.ScoreTable;
            }

            foreach (var score in _ScoreTable)
            {
                print(score.BestScore);
            }
        }

        }
    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/bestscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Score data = JsonUtility.FromJson<Score>(json);
            if (data != null)
            {
                _BestScore = data.BestScore;
                _BestScorePlayer = data.BestScorePlayerName;
                
            }
        }
    }

}
