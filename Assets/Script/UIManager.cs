using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject InGamePanel;

    private void OnEnable()
    {

    }
    private void OnDisable()
    {
        GameManager.singleton.PauseOn -= ActivatePausePanel;
        GameManager.singleton.PauseOff -= DisactivatePausePanel;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.singleton.PauseOn += ActivatePausePanel;
        GameManager.singleton.PauseOff += DisactivatePausePanel;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
