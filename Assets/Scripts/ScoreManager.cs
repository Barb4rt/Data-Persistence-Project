using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using UnityEngine;
using System;
using System.Linq;

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
        return _ScoreTable[0].ScoreValue;
    }

    public string GetBestPlayer()
    {
        return _ScoreTable[0].ScorePlayerName;
    }

    public List<Score> GetScoreList()
    {

        return _ScoreTable;
       
    }


    public void NewHighScore ( int newScore)
    {
        _BestScore = newScore;
        _BestScorePlayer = _PlayerName;
        SaveBestScore();

    }
    public void AddNewScore(int newScoreValue)
    {
        Score newScore = new Score
        {
            ScoreValue = newScoreValue,
            ScorePlayerName = _PlayerName
        };
        _ScoreTable.Add(newScore);
        _ScoreTable = _ScoreTable.OrderByDescending(score => score.ScoreValue).ToList();
        _ScoreTable = _ScoreTable.Take(10).ToList();
        string json = JsonUtility.ToJson(new ScoreTable { ScoreTableList = _ScoreTable });
        File.WriteAllText(Application.persistentDataPath + "/bestscore.json", json);
    }
    private void SaveBestScore()
    {
        List<Score> sortedScores = _ScoreTable.OrderByDescending(score => score.ScoreValue).ToList();
        List<Score> topScores = sortedScores.Take(10).ToList();
        string json = JsonUtility.ToJson(new ScoreTable { ScoreTableList = topScores });
        File.WriteAllText(Application.persistentDataPath + "/bestscore.json", json);
    }
    public void LoadScoreTable()
    {
        string path = Application.persistentDataPath + "/bestscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ScoreTable data = JsonUtility.FromJson<ScoreTable>(json);
            print(data.ScoreTableList);
            // Affichage des scores (pour vérification)
            foreach (var score in data.ScoreTableList)
            {
                print("Best Score: " + score.ScoreValue + " | Player Name: " + score.ScorePlayerName);
            }
            if (data != null)
            {
                _ScoreTable = data.ScoreTableList;
            }

        }
        else
        {
            Debug.LogWarning("Le fichier de score n'existe pas.");
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
                _BestScore = data.ScoreValue;
                _BestScorePlayer = data.ScorePlayerName;
                
            }
        }
    }

}
