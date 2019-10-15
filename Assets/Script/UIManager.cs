using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject InGamePanel;
    public GameObject Lvl1Panel;
    public GameObject lvl2Panel;
    public GameObject VictoryPanel;
    public GameObject GameOverPanel;

    public Text CollTextValue;
    public Text LifeTextValue;

    private void OnDisable()
    {
        GameManager.singleton.PauseOn -= ActivatePausePanel;
        GameManager.singleton.PauseOff -= DisactivatePausePanel;

        GameManager.singleton.Panl1 -= ChangeLevelSelection1;
        GameManager.singleton.Panl2 -= ChangeLevelSelection2;

        GameManager.singleton.Victory -= VicPanel;
        GameManager.singleton.GameOver -= GOPanel;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.singleton.PauseOn += ActivatePausePanel;
        GameManager.singleton.PauseOff += DisactivatePausePanel;

        GameManager.singleton.Panl1 += ChangeLevelSelection1;
        GameManager.singleton.Panl2 += ChangeLevelSelection2;

        GameManager.singleton.Victory += VicPanel;
        GameManager.singleton.GameOver += GOPanel;
    }

    public void ActivatePausePanel()
    {
        PausePanel.SetActive(true);
        InGamePanel.SetActive(false);
    }
    public void DisactivatePausePanel()
    {
        PausePanel.SetActive(false);
        InGamePanel.SetActive(true);
    }

    public void ChangeLevelSelection1()
    {
        Lvl1Panel.SetActive(false);
        lvl2Panel.SetActive(true);
    }
    public void ChangeLevelSelection2()
    {
        lvl2Panel.SetActive(false);
        Lvl1Panel.SetActive(true);
    }

    public void VicPanel()
    {
        VictoryPanel.SetActive(true);
        GameOverPanel.SetActive(false);
    }
    public void GOPanel()
    {
        VictoryPanel.SetActive(false);
        GameOverPanel.SetActive(true);
    }
}
