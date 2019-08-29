using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class FlowSM : MonoBehaviour
{
    public Animator SMController;

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
}
