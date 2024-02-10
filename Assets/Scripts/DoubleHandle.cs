using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

// Interactable that requires two hands to interact with
public class DoubleHandle : XRBaseInteractable
{
    protected HashSet<IXRInteractor> interactors = new HashSet<IXRInteractor>();
    
    protected override void OnActivated(ActivateEventArgs args)
    {
        
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        interactors.Add(args.interactorObject);
    }
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        interactors.Add(args.interactorObject);
    }
    protected override void OnDeactivated(DeactivateEventArgs args)
    {
        
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (interactors.Count == 2)
        {
            
        }

    }
}
