using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public FlowSM StateMachine;
    public MySceneManager Scenemg;

    // Start is called before the first frame update
    void Start()
    {
        SingletonFunction();
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SingletonFunction()
    {
        //Check if instance already exists
        if (singleton == null)

            //if not, set instance to this
            singleton = this;

        //If instance already exists and it's not this:
        else if (singleton != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }

    public void SetUp()
    {
        StateMachine = FindObjectOfType<FlowSM>();
        Scenemg = FindObjectOfType<MySceneManager>();
    }
}
