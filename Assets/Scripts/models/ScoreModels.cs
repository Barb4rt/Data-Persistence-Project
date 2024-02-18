using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [System.Serializable]
    public class Score
    {
        public int ScoreValue;
        public string ScorePlayerName;

    }

    [System.Serializable]
    public class ScoreTable
{
        public List<Score> ScoreTableList;
    }
