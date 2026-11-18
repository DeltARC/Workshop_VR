using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SnapPot : MonoBehaviour
{
    public GameObject PotPlacement;
    public GameObject Summoning;

    public bool isplace = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        FlowerPot flowerPot = other.GetComponent<FlowerPot>();

        
        if (FlowerPot)
        {
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.position = PotPlacement.transform.position;
            other.transform.rotation = PotPlacement.transform.rotation;
            Debug.Log("ok");
            isplace =true;
        }

        Summoning.GetComponent<Summon>().CheckSumonning();
    }

}
