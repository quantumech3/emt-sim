using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class DragBodyInteractable : XRBaseInteractable
{
    private IXRInteractor interactor;
    private bool shouldDrawLine = false;
    private LineRenderer lineRenderer;

    public float force_multiplier = 1.5f;
    public float force_deadzone = 0.0f;
    public float max_force = 5.0f;
    public static int handsUsed = 0;

    protected override void OnActivated(ActivateEventArgs args)
    {
        interactor = args.interactorObject;
        shouldDrawLine = true;
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        handsUsed++;
    }
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        handsUsed--;
        shouldDrawLine = false;
    }
    protected override void OnDeactivated(DeactivateEventArgs args)
    {
        shouldDrawLine = false;
    }

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
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
                    transform.parent.GetComponent<Rigidbody>().AddForceAtPosition(-force, forceLocation);
                }                
            }
        }

    }
}
