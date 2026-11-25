using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Dirt : MonoBehaviour
{
    // Le script est attache a Dirt dans le prefab du pot

    public GameObject seedPlacement;
    public GameObject plantRef;

    [SerializeField] private bool IsItSunny;
    private bool seedPlanted = true;
    public delegate void SeedInDirt();
    public static event SeedInDirt SeedPlanted;

    void OnTriggerEnter(Collider other)
    {
        Seed seed = other.GetComponent<Seed>();

        // SI Seed touche le collider ALORS il se place a l'emplacement de la graine et deviens l'enfant de seedPlacement.
        if (seed)
        {            // Permet à la graine de ne plus pouvoir être prise et de suivre le pot en devenant un enfant de seePlacement.
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<XRGrabInteractable>().enabled = false;
            other.transform.SetParent(seedPlacement.transform, true);
            // Permet a la graine de rentrer dans la terre
            other.transform.position = seedPlacement.transform.position;
            other.transform.rotation = seedPlacement.transform.rotation;

            // Dit qu'une graine a etait planter
            if (seedPlanted)
            {
                SeedPlanted?.Invoke();
                seedPlanted = false;
            }
        }
    }
}