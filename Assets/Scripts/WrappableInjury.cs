using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrappableInjury : MonoBehaviour
{
    public bool isBeingWrapped = false;
    public float totalAngle = 0;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setBeingWrapped(bool isWrapped)
    {
        isBeingWrapped = isWrapped;
    }
}