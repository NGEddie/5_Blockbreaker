﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{
    public void LoadNextScene()
    {
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex;

        if (GetCurrentSceneIndex() < SceneManager.sceneCountInBuildSettings -1)
        {
            nextSceneIndex = GetCurrentSceneIndex() + 1;
        }
        else
        {
            LoadStartScene();
            return;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

    public void LoadStartScene()
    {
        FindObjectOfType<GameStatus>().ResetGame();
        SceneManager.LoadScene(0);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public int GetCurrentSceneIndex()
    {
         return SceneManager.GetActiveScene().buildIndex;
    }
}

