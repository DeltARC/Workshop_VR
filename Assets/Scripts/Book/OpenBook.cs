using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class OpenBook : MonoBehaviour
{
    [SerializeField] public GameObject CoverTop;
    [SerializeField] public GameObject CoverBottom;
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
        else 
        {
            //isOpen = false;
        }
    }

    void Openbook()
    {
        CoverTop.transform.Rotate(0,90,0);
        CoverBottom.transform.Rotate(0,-90,0);

        Debug.Log("ouvert");
        return;
    }
}
