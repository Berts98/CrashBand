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
    public UIManager UI;
    public int currentColl;

    #region Actions
    public Action OnClick;
    public Action PauseOn;
    public Action PauseOff;
    public Action Panl1;
    public Action Panl2;
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
                case "Level1":
                    Scenemg.Level1();
                    break;
                /*case "Level2":
                    Scenemg.Level2();
                    break;*/
                case "BackToSelection":
                    Scenemg.LevelSelection();
                    break;
                case "RetryLevel":
                    Scenemg.Level1();
                    break;
                /*case "RetryLevel2":
                    Scenemg.Level2();
                    break;*/
                case "Next":
                    UI.ChangeLevelSelection1();
                    break;
                case "Previous":
                    UI.ChangeLevelSelection2();
                    break;
                default:
                    break;
            }
        }
    }

    public void AddCollectable(int CollToAdd)
    {
        currentColl += CollToAdd;
        UI.CollTextValue.text = "X " + currentColl;
    }

    public void SetUp()
    {
        StateMachine = FindObjectOfType<FlowSM>();
        Scenemg = FindObjectOfType<MySceneManager>();
        UI = FindObjectOfType<UIManager>();
    }
}
