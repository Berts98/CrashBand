using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
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

    /*public void Level2()
    {
        SceneManager.LoadScene(3);
        GameManager.singleton.StateMachine.SMController.SetTrigger("GoToInit");
    }*/

    public void EndLevel()
    {
        SceneManager.LoadScene(3);
        GameManager.singleton.StateMachine.SMController.SetTrigger("GoToEndLevel");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
