using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
public class CallbackInteractor : JobInteractable
{
    public IKControl ikControl;
    void Start()
    {
        jobID = 0;
        ikControl.isActivated = false;
    }

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        if (jobID != StateManager.GetState())return;
        ikControl.interactor = args.interactorObject;
        Debug.Log("OnSelectEntering called");
    }
    

    protected override void OnActivated(ActivateEventArgs args)
    {
        if (jobID != StateManager.GetState())return;
        ikControl.isActivated = true;
    }

    protected override void OnDeactivated(DeactivateEventArgs args)
    {
        if (jobID != StateManager.GetState())return;
        ikControl.isActivated = false;
    }
    // update method to check if wrapped is true.
    private void Update()
    {
        if (jobID != StateManager.GetState()){
            ikControl.isActivated = false;
        }
        QuickCheck();
    }
}
