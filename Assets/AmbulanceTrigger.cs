using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmbulanceTrigger : MonoBehaviour
{
    public TMP_Text text;
    private bool reachedAmbulance = false;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Get back to the patient and get them into the ambulance!";
    }
    // On trigger enter, see if object contains a child named "Body" or is "Body"
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Body" || other.gameObject.transform.Find("Body") != null)
        {
            text.text = "Nice work! You've successfully loaded the patient into the ambulance. Now, let's get them to the hospital!";
            reachedAmbulance = true;
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        // check if the object is the patient
        if (other.gameObject.name == "Body" || other.gameObject.transform.Find("Body") != null)
        {
            if (reachedAmbulance){
                text.text = "Hey! You're not done yet! Get back to the patient and get them into the ambulance!";
            }else{
                text.text = "Get back to the patient and get them into the ambulance!";
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
