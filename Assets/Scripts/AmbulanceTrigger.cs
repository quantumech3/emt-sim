using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using UnityEngine.Animations;

public class AmbulanceTrigger : MonoBehaviour
{
    public TMP_Text text;
    private bool reachedAmbulance = false;
    private float timer = 0.0f;

    public GameObject body;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    // On trigger enter, see if object contains a child named "Body" or is "Body"
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Char_Base" || other.gameObject.transform.Find("Char_Base") != null)
        {
            text.text = "Nice work! You've successfully loaded the patient into the ambulance. Now, let's get them to the hospital!\n Your final time: " + timer.ToString("F2") + " seconds.";
            reachedAmbulance = true;

            StateManager.IncrementState();
            // set the body to the position of the parent object
            // parent absolute position
            Vector3 parentPosition = this.transform.parent.position;
            body.transform.position = new Vector3(parentPosition.x, parentPosition.y, parentPosition.z);
            // set body rotation to -90,0,0
            body.transform.rotation = Quaternion.Euler(-90, 0, -90);
            // freeze position and rotation
            body.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        // check if the object is the patient
        if (other.gameObject.name == "Char_Base" || other.gameObject.transform.Find("Char_Base") != null)
        {
            // if (reachedAmbulance){
            //     text.text = "Hey! You're not done yet! Get back to the patient and get them into the ambulance!";
            // }else{
            //     text.text = "Get back to the patient and get them into the ambulance!";
            // }
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
}
