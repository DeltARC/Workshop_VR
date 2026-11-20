using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Dirt : MonoBehaviour
{
    // Le script est attache a Dirt dans le prefab du pot

    public GameObject seedPlacement;
    public GameObject SeedPrefab;
    public Collider SeedCol;
    public GameObject parentObject;

    public bool IsPlace = false;

    void OnTriggerEnter(Collider other)
    {
        Seed seed = other.GetComponent<Seed>();

        // SI Seed touche le collider ALORS il se place a l'emplacement de la graine et deviens l'enfant de seedPlacement.
        if (seed)
        {
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<XRGrabInteractable>().enabled = false;
            other.transform.SetParent(seedPlacement.transform, true);
            other.transform.position = seedPlacement.transform.position;
            other.transform.rotation = seedPlacement.transform.rotation;

            Debug.Log("Pousse?");
            IsPlace = true;

            if (IsPlace == false)
            {
                //Instantiate(SeedPrefab, seedPlacement.transform.position, Quaternion.identity, gameObject.transform);

                Instantiate(SeedPrefab, seedPlacement.transform.position, SeedPrefab.transform.rotation);
                other.transform.SetParent(seedPlacement.transform);
            }
        }
    }
}