using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CallbackInteractor : XRBaseInteractable
{
    public IKControl ikControl;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        ikControl.interactor = args.interactorObject;
        Debug.Log("OnSelectEntering called");
    }
    
    // Update is called once per frame
    void Update()
    {
    }

    protected override void OnActivated(ActivateEventArgs args)
    {
        ikControl.isActivated = true;
    }

    protected override void OnDeactivated(DeactivateEventArgs args)
    {
        ikControl.isActivated = false;
    }
}
