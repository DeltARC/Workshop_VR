using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System.Collections;

public class SnapPot : MonoBehaviour
{
    public GameObject PotPlacement;

    [SerializeField] private GameObject Pot;

    public bool isPlaced = false;
    private bool canBePickedUp = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        FlowerPot flowerPot = other.GetComponent<FlowerPot>();
        
        StartCoroutine(WaitBeforeTrigger(2f));
        
        if (flowerPot && canBePickedUp == true)
        {
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<XRGrabInteractable>().enabled = false;
            other.transform.position = PotPlacement.transform.position;
            other.transform.rotation = PotPlacement.transform.rotation;
            Debug.Log("ok");
            isPlaced = true;
            if (isPlaced == true)
            {
                canBePickedUp = false;
                StartCoroutine(WaitForSeconds(2f));
            }
            

        }

        //Summoning GetComponent<Summon>().CheckSumonning();
    }

    private IEnumerator WaitForSeconds(float seconds)
    {
        Debug.Log("fghhjtrezgrhdfd");
        yield return new WaitForSeconds(seconds);
        Pot.GetComponent<XRGrabInteractable>().enabled = true;
        Pot.GetComponent<Rigidbody>().isKinematic = false;
        isPlaced = false;
        canBePickedUp = true;
        Debug.Log("ok 2seconds");
    }

    private IEnumerator WaitBeforeTrigger(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

}


