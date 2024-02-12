using UnityEngine;
using System;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Animator))]

public class IKControl : MonoBehaviour {

    private Animator animator;
    public IXRInteractor interactor;
    public bool isActivated;

    void Start ()
    {
        animator = GetComponent<Animator>();
    }

    //a callback for calculating IK
    void OnAnimatorIK(int layerIndex)
    {
        if (interactor != null && isActivated)
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            animator.SetIKPosition(AvatarIKGoal.RightHand, interactor.transform.position);
            Debug.Log("OnAnimatorIK being called");
        }else{
            // set to tpose.
            // animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            // animator.SetIKPosition(AvatarIKGoal.RightHand, interactor.transform.position);
            // animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            // animator.SetIKPosition(AvatarIKGoal.LeftHand, interactor.transform.position);
            // animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0);
            // animator.SetIKPosition(AvatarIKGoal.RightFoot, interactor.transform.position);
            // animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
            // animator.SetIKPosition(AvatarIKGoal.LeftFoot, interactor.transform.position);

        }
    }  
}