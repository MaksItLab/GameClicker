using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class UI_Scripts : MonoBehaviour
{
    public static Action onSaved;
    public static Action onLoaded;


    public void Start()
    {
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Debug.Log("Игра закрылась");
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void SaveData()
    {
        Debug.Log("Save in process");
        if (onSaved != null)
        {
            onSaved.Invoke();
        }
    }

    public void LoadData()
    {
        Debug.Log("Load in process");
        if (onLoaded != null)
        {
            SceneManager.LoadScene(1);
            onLoaded.Invoke();
        }
    }

}
