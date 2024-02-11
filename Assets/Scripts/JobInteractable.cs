using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;


public class JobInteractable : XRBaseInteractable
{
    protected int jobID;
    protected bool selected = false;

    

    protected override void OnActivated(ActivateEventArgs args)
    {
        // do nothing if not the correct jobID
        if (jobID != StateManager.GetState())
        {
            return;
        }
        selected = true;
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (jobID != StateManager.GetState())
        {
            return;
        }
        selected = true;
    }
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        if (jobID != StateManager.GetState())
        {
            return;
        }
        selected = false;
    }
    protected override void OnDeactivated(DeactivateEventArgs args)
    {
        if (jobID != StateManager.GetState())
        {
            return;
        }
        selected = false;
    }

    private void Start()
    {
        
    }

    protected void QuickCheck()
    {
        // disable or enable all components based on jobID.
        if (jobID == StateManager.GetState())
        {
            if (GetComponent<MeshRenderer>() != null)
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
            if (GetComponent<MeshCollider>() != null)
            {
                GetComponent<MeshCollider>().enabled = true;
            }
        }
        else
        {
            // disable all components
            // check if components exist, and if they do, disable them.
            if (GetComponent<MeshRenderer>() != null)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            if (GetComponent<MeshCollider>() != null)
            {
                GetComponent<MeshCollider>().enabled = false;
            }
            // call start method.
            Start();
            selected = false;
        }
        
    }
}
