using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderTLevel : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject InGamePanel;
    public GameObject Panl1;
    public GameObject Panl2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpChangeSelection()
    {
        GameManager.singleton.UI.Lvl1Panel = Panl1;
        GameManager.singleton.UI.lvl2Panel = Panl2;
    }

    public void SetUpTLvel()
    {
        GameManager.singleton.UI.InGamePanel = InGamePanel;
        GameManager.singleton.UI.PausePanel = PausePanel;
    }
}
