﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        GameManager.singleton.StateMachine.SMController.SetTrigger("GoToMenu");
    }

    public void LevelSelection()
    {
        SceneManager.LoadScene(1);
        GameManager.singleton.StateMachine.SMController.SetTrigger("GoToSelection");
    }

    public void Level1()
    {
        SceneManager.LoadScene(2);
        GameManager.singleton.StateMachine.SMController.SetTrigger("GoToInit");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
