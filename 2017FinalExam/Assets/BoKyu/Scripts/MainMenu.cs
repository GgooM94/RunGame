﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour {

	public void PlayGame()
    {
        SceneManager.LoadScene("scPlay", LoadSceneMode.Additive);

    }

    public void QuitGame()
    {
        Debug.Log("Quit!!");
        Application.Quit();     
    }

    public void Runagain()
    {

    }

    public void Mainmmenu()
    {
        SceneManager.LoadScene("scMap");
    }
}
