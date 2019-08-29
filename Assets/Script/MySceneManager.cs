using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public void LevelSelection()
    {
        SceneManager.LoadScene(1);
        GameManager.singleton.StateMachine.SMController.SetTrigger("GoToSelection");
    }

    public void Level1()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
