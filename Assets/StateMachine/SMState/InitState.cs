using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitState : StateMachineBehaviour
{
    public FlowSM SM;
    public LoaderTLevel Loader;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SM = GameManager.singleton.StateMachine;
        Loader = FindObjectOfType<LoaderTLevel>();
        Loader.SetUpTLvel();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SM.EndInit();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
