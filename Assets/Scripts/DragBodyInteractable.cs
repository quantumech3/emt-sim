using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class DragBodyInteractable : JobInteractable
{
    private IXRInteractor interactor;
    private bool shouldDrawLine = false;
    private LineRenderer lineRenderer;


    public GameObject body;
    public float force_multiplier = 1.5f;
    public float force_deadzone = 0.0f;
    public float max_force = 5.0f;
    public static int handsUsed = 0;
    // text reference.
    public TMP_Text text;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        jobID = 1;
        // hide the line renderer
        lineRenderer.enabled = false;
        shouldDrawLine = false;
    }

    protected override void OnActivated(ActivateEventArgs args)
    {
        if (jobID != StateManager.GetState())return;
        interactor = args.interactorObject;
        shouldDrawLine = true;
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (jobID != StateManager.GetState())return;
        handsUsed++;
    }
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        if (jobID != StateManager.GetState())return;
        handsUsed--;   
        shouldDrawLine = false;
    }
    protected override void OnDeactivated(DeactivateEventArgs args)
    {
         if (jobID != StateManager.GetState())return;
        shouldDrawLine = false;
    }

    private void Update()
    {
        QuickCheck();
        if (jobID != StateManager.GetState())return;
        lineRenderer.enabled = shouldDrawLine;
        if (shouldDrawLine)
        {
            lineRenderer.SetPosition(0, interactor.transform.position);
            lineRenderer.SetPosition(1, transform.position);
            if (Vector3.Distance(interactor.transform.position, transform.position) > force_deadzone)
            {
                Vector3 force = lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0);
                Vector3 forceLocation = transform.position;
                if (handsUsed > 1){
                    force *= force_multiplier;
                    if (force.magnitude > max_force){
                        force = force.normalized * max_force;
                    }
                    // also apply some gravity force to the body.
                    // force += new Vector3(0, -9.8f, 0);
                    body.GetComponent<Rigidbody>().AddForceAtPosition(-force, forceLocation);
                }else{
                    text.text = "You need to use both hands to move the body.";
                }         
            }
        }
        

    }
}
