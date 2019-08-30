using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public FlowSM StateMachine;
    public MySceneManager Scenemg;

    #region Actions
    public Action OnClick;
    #endregion

    private void Awake()
    {
        SingletonFunction();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        OnClick += OnClickTest; 
    }

    private void OnDisable()
    {
        OnClick -= OnClickTest;
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

    private void OnClickTest()
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            switch (EventSystem.current.currentSelectedGameObject.name)
            {
                case "BackToMenu":
                    Scenemg.Menu();
                    break;
                case "PlayButton":
                    Scenemg.LevelSelection();
                    break;
                default:
                    break;
            }
        }
    }

    public void SetUp()
    {
        StateMachine = FindObjectOfType<FlowSM>();
        Scenemg = FindObjectOfType<MySceneManager>();
    }
}
