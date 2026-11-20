using System;
using UnityEngine;

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
            Debug.Log("Gravity true / Kinematic false");

        }

        else if (Cover.GetComponent<Rigidbody>().isKinematic == true)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log("Gravity false / Kinematic true");

        }
    }
}

