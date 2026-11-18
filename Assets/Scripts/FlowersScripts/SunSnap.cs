using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SunSnap : MonoBehaviour
{
    public GameObject SunPlacement;

    private bool sunOnFlower = false;
    public bool IsPlace = false;

    void FlowerOnSunlight(Collider other)
    {

        FlowerPot flowerpPot = other.GetComponent<FlowerPot>();

        if (flowerpPot)
        {
            // Empeche l'objet de bouger, et le place sur le position voulu.
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.position = SunPlacement.transform.position;
            other.transform.rotation = SunPlacement.transform.rotation;
            Debug.Log("Sun");
            IsPlace = true;
            sunOnFlower = true;
        }else
        {
            sunOnFlower = false;
            Debug.Log("Bougabouga");
        }
    }
}
