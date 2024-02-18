using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Text GameOverBestScore;
    public Text GameOverScore;
    private bool m_GameOver = true;
    // Start is called before the first frame update
    void Start()
    {
        GameOverBestScore.text = $"Best score: {ScoreManager.Instance.GetBestPlayer()}: {ScoreManager.Instance.GetBestScore()}";
        GameOverScore.text = $"Your score: {ScoreManager.Instance.GetInstanceScore()}";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_GameOver = false;
            SceneManager.LoadScene(1);
        }
    }
}
