using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Dirt : MonoBehaviour
{
    // Le script est attache a Dirt dans le prefab du pot

    public GameObject seedPlacement;
    public GameObject seedGrowing;

    public bool IsPlace = false;

    void OnTriggerEnter(Collider other)
    {
        Seed seed = other.GetComponent<Seed>();

        if (seed)
        {
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<XRGrabInteractable>().enabled = false;
            other.transform.position = seedPlacement.transform.position;
            other.transform.rotation = seedPlacement.transform.rotation;
            //Destroy(seed.gameObject);
            Debug.Log("Pousse?");
            IsPlace = true;
        }
    }
}
