using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Animator))]
public class FlowSM : MonoBehaviour
{
    public Animator SMController;

    #region Actions
    public Action EndInit;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        SMController = GetComponent<Animator>();
        StateBehaviourBase.Context context = new StateBehaviourBase.Context()
        {
            SetupDone = false,
        };
        foreach (StateBehaviourBase state in SMController.GetBehaviours<StateBehaviourBase>())
        {
            ///eseguo setup iniziale
            state.Setup(context);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        EndInit += GoToLevel;
    }

    private void OnDisable()
    {
        EndInit -= GoToLevel;
    }

    public void GoToLevel()
    {
        SMController.SetTrigger("GoToLevel");
    }
}
