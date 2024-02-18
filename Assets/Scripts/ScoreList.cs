using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreList : MonoBehaviour
{
    public GameObject ItemPrefab;
    public string[] itemTexts;
    
    
    
    void Start()
    {
      List<Score> scores = ScoreManager.Instance.GetScoreList();
    List<Score> topScores = scores.GetRange(0, Mathf.Min(10, scores.Count));
        for (int i = 0; i < topScores.Count; i++)
        {
            GameObject obj = Instantiate(ItemPrefab);
            obj.transform.parent = transform;
            TextMeshProUGUI index = obj.transform.Find("Index").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI playerName = obj.transform.Find("PlayerName").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI scoreText = obj.transform.Find("Score").GetComponent<TextMeshProUGUI>();
            if (index && playerName && scoreText)
            {
                index.text = (i + 1).ToString();
                playerName.text = topScores[i].ScorePlayerName; 
                scoreText.text = topScores[i].ScoreValue.ToString();
            }
            else
            {
                Debug.LogWarning("Composant TextMeshPro introuvable dans l'objet généré.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
