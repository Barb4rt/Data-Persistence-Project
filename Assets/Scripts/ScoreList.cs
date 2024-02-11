using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreList : MonoBehaviour
{
    public GameObject ItemPrefab;
    public string[] itemTexts;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject obj = Instantiate(ItemPrefab);
            obj.transform.parent = transform;
            TextMeshProUGUI index = obj.transform.Find("Index").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI playerName = obj.transform.Find("PlayerName").GetComponent<TextMeshProUGUI>();
            if (index != null)
            {
                // Modifier le texte comme souhaité
                index.text = (i+1).ToString();
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
