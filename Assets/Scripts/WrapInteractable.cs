using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class WrapInteractable : XRBaseInteractable
{
    private IXRInteractor interactor;
    private bool shouldDrawLine = false;
    private LineRenderer lineRenderer;
    public TMP_Text text;
    private Vector3 theta;
    private Vector3 _theta;
    private float dtheta;
    private float int_dtheta;
    public GameObject gause;

    protected override void OnActivated(ActivateEventArgs args)
    {
        interactor = args.interactorObject;
        shouldDrawLine = true;
        _theta = transform.position - interactor.transform.position;
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
        }

        theta = transform.position - interactor.transform.position;
        dtheta = Vector3.SignedAngle(_theta, theta, transform.up);
        _theta = theta;
        
        int_dtheta += dtheta;

        text.text = int_dtheta.ToString();

        // 5 rotations and your done applying the gause
        if (int_dtheta >= 360 * 5)
        {
            gause.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
