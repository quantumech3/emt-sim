using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandInteractable : XRBaseInteractable
{
    public Animator ikAnimator;
    public IXRInteractor interactor;
    public GameObject rightHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        interactor = args.interactorObject;
        Debug.Log("Called");
    }

    void OnAnimatorIK(int layerIndex)
    {
        Debug.Log("AnimatorIK being called");
        if (isSelected && interactor != null)
        {
            ikAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand,1);
            ikAnimator.SetIKPosition(AvatarIKGoal.RightHand, interactor.transform.position);
            Debug.Log("IK position is being set");
        }
        else
        {
        }
    }
}
