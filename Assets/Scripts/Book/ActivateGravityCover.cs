using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ActivateGravityCover : MonoBehaviour
{

    [SerializeField] public GameObject Cover;

    private bool grab = false;


    // Update is called once per frame
    void Update()
    {
        if (Cover.GetComponent<Rigidbody>().useGravity == true)
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<XRGrabInteractable>().enabled = true;
            Debug.Log("Gravity true / Kinematic false");

        }

        else if (Cover.GetComponent<Rigidbody>().isKinematic == true)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<XRGrabInteractable>().enabled = false;
            Debug.Log("Gravity false / Kinematic true");

        }
    }
}

