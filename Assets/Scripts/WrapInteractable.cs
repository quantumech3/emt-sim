using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class WrapInteractable : JobInteractable
{
    private IXRInteractor interactor;
    private bool shouldDrawLine = false;
    private LineRenderer lineRenderer;
    public TMP_Text text;
    private Vector3 theta;
    private Vector3 _theta;
    private float dtheta;
    private float int_dtheta;
    public int num_rotations = 5;

    public GameObject gause;
    public GameObject body;
    
    public Vector3 max_size;

    // constructor
    public WrapInteractable()
    {
        jobID = 0;
    }
    

    protected override void OnActivated(ActivateEventArgs args)
    {
        if(StateManager.GetState() != jobID) return;
        interactor = args.interactorObject;
        shouldDrawLine = true;
        _theta = transform.position - interactor.transform.position;
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(StateManager.GetState() != jobID) return;
    }
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        if(StateManager.GetState() != jobID) return;
        shouldDrawLine = false;
    }
    protected override void OnDeactivated(DeactivateEventArgs args)
    {
        if(StateManager.GetState() != jobID) return;
        shouldDrawLine = false;
    }

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        max_size = gause.transform.localScale;
        gause.transform.localScale = new Vector3(max_size.x, max_size.y, 0);
    }

    private void Update()
    {
        QuickCheck();
        if (StateManager.GetState() != jobID) return;
        if (interactor != null)
        {
            lineRenderer.enabled = shouldDrawLine;
            if (shouldDrawLine)
            {
                lineRenderer.SetPosition(0, interactor.transform.position);
                lineRenderer.SetPosition(1, transform.position);
            }

            theta = transform.position - interactor.transform.position;
            dtheta = Vector3.SignedAngle(_theta, theta, transform.up);
            _theta = theta;
        
            int_dtheta += dtheta;
            double rotated = int_dtheta / 360;
            if (rotated < 0){
                rotated = -rotated;
            }
            double percent = rotated / num_rotations;
            percent = Math.Round(1.0 - percent, 2)*100;
            text.text = "Gauze left:" + percent.ToString() + "% . \n Keep on wrapping the gauze!";

            // 5 rotations and your done applying the gauze. Doesn't matter if it's clockwise or counter-clockwise
            if (rotated >= num_rotations)
            {
                text.text = "Nice work. Now it is time to bring the patient onto the stretcher. \n You must grab the patient by both hands and feet. Bring them to the stretcher.";

                StateManager.IncrementState();
                // clear out line renderer
                lineRenderer.enabled = false;
                // remove constraints on body's rigidbody
                body.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }else{
                // set size to 0.5 of max + a little bit more depending on # of rotations
                gause.transform.localScale = new Vector3(max_size.x, max_size.y, max_size.z * (float)(rotated/num_rotations));
            }
        }
    }
}
