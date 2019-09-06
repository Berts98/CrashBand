using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderTLevel : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject InGamePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetUpTLvel()
    {
        GameManager.singleton.UI.InGamePanel = InGamePanel;
        GameManager.singleton.UI.PausePanel = PausePanel;
    }
}
