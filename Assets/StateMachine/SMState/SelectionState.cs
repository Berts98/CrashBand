﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionState : StateMachineBehaviour
{
    public LoaderTLevel Loader;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneManager.sceneLoaded += Test;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
            GameManager.singleton.StateMachine.SMController.SetTrigger("GoToMenu");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    private void Test(Scene _scene, LoadSceneMode _loadSceneMode)
    {
        Loader = FindObjectOfType<LoaderTLevel>();
        Loader.SetUpChangeSelection();
        SceneManager.sceneLoaded -= Test;
    }
}
