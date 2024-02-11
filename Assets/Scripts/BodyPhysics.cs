using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
public class BodyPhysics : JobInteractable
{
   
    void Start()
    {
        // disable collider and mesh renderer
        jobID = 1;
    }
    private void Update()
    {
        if (jobID == StateManager.GetState())
        {
            // add rigidbody component
            if (GetComponent<Rigidbody>() == null)
            {
                gameObject.AddComponent<Rigidbody>();
                // set mass to 0.3
                GetComponent<Rigidbody>().mass = 0.3f;
            }
        }
    }
}
