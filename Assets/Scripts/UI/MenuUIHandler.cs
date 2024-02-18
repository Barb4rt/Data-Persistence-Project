using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public Color errorColor = Color.red;
    public Color originalImageColor = Color.white;

    public void SetPlayerName(string _playerName)
    {
      
            if (string.IsNullOrEmpty(_playerName))
            {
                return; 
            }

            ScoreManager.Instance.SetPlayerName(_playerName);
        
    }

    private void Start()
    {

    }
    public void StartNew()
    {
        if(string.IsNullOrEmpty(ScoreManager.Instance.GetPlayerName())) {

            StartCoroutine(FlashRed());
            return; }
        inputField.textComponent.color = originalImageColor;
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }


    IEnumerator FlashRed()
    {
        inputField.image.color = errorColor;
        yield return new WaitForSeconds(1f);
        inputField.image.color = originalImageColor;
    }
}
