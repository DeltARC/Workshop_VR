using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class OpenBook : MonoBehaviour
{
    [SerializeField] public GameObject CoverTop;
    [SerializeField] public GameObject CoverBottom;
    [SerializeField] public GameObject CoverBack;
    [SerializeField] public GameObject[] Page;
    private bool isOpen= false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {

        if (GetComponent<Rigidbody>().useGravity == false && !isOpen)
        {
            Debug.Log(isOpen);
            Debug.Log(GetComponent<Rigidbody>().useGravity);
            isOpen = true;
            Openbook();
        }
        
    }

    void Openbook()
    {
        CoverTop.SetActive(false);
        CoverBottom.SetActive(false);
        CoverBack.SetActive(true);

        for(int i = 0; i < 3; i++)
        {
            Page[i].GetComponent<XRGrabInteractable>().enabled = true;
            Page[i].GetComponent<Rigidbody>().freezeRotation = false;
            
            Debug.Log(i);
        }

        Debug.Log("ouvert");
        return;
    }
}
