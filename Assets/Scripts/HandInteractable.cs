using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandInteractable : JobInteractable
{
    public Animator ikAnimator;
    public IXRInteractor interactor;
    public GameObject rightHand;

    // Start is called before the first frame update
    void Start()
    {
        jobID = 0;
    }

    // Update is called once per frame
    void Update()
    {
        QuickCheck();
    }

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        if (jobID != StateManager.GetState())return;
        interactor = args.interactorObject;
    }

    void OnAnimatorIK(int layerIndex)
    {
        if (jobID != StateManager.GetState())return;
        if (isSelected && interactor != null)
        {
            ikAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand,1);
            ikAnimator.SetIKPosition(AvatarIKGoal.RightHand, interactor.transform.position);
            Debug.Log("IK position is being set");
        }
    }
}
