using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class OpenBook : MonoBehaviour
{

    [SerializeField] public GameObject CoverBack;
    [SerializeField] public GameObject[] Page;
    private bool isOpen = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("ok");
    }

    void Update()
    {

        if (CoverBack.GetComponent<Rigidbody>().useGravity == false && !isOpen)
        {
            Debug.Log(isOpen);
            isOpen = true;
            Openbook();
        }

        if (CoverBack.GetComponent<Rigidbody>().useGravity == true && isOpen)
        {
            Debug.Log(isOpen);
            isOpen = false;
            NotHeldbook();
        }

    }

    void Openbook()
    {

        for (int i = 0; i < 3; i++)
        {
            Page[i].GetComponent<XRGrabInteractable>().enabled = true;


            Debug.Log(i);
        }

        Debug.Log("Pris");
        return;
    }
    void NotHeldbook()
    {

        for (int i = 0; i < 3; i++)
        {
            Page[i].GetComponent<XRGrabInteractable>().enabled = false;


            Debug.Log(i);
        }

        Debug.Log("Non Pris");
        return;
    }
}

