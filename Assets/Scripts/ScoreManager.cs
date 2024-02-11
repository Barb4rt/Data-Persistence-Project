using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private string _PlayerName;
    private int _BestScore;
    private string _BestScorePlayer;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
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
    class SaveData
    {
        public int BestScore;
        public string BestScorePlayerName;
    }

    public void NewHighScore ( int newScore)
    {
        _BestScore = newScore;
        _BestScorePlayer = _PlayerName;
        SaveBestScore();

    }
    private void SaveBestScore()
    {
        SaveData data = new SaveData();

        data.BestScore = _BestScore;
        data.BestScorePlayerName = _BestScorePlayer;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/bestscore.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/bestscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log(data.BestScore);
            if (data != null)
            {
                _BestScore = data.BestScore;
                _BestScorePlayer = data.BestScorePlayerName;
                
            }
        }
    }

}
