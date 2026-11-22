
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SnapPot : MonoBehaviour
{
    [SerializeField] private Transform potPlacement;

    private FlowerPot currentPot;
    private XRGrabInteractable currentGrab;

    private bool isInsideZone = false;

    private void OnTriggerEnter(Collider other)
    {
        FlowerPot flowerPot = other.GetComponentInParent<FlowerPot>();

        if (flowerPot == null)
            return;

        currentPot = flowerPot;
        currentGrab = flowerPot.GetComponent<XRGrabInteractable>();

        if (currentGrab == null)
            return;

        isInsideZone = true;

        currentGrab.selectExited.AddListener(OnPotReleased);
    }

    private void OnTriggerExit(Collider other)
    {
        FlowerPot flowerPot = other.GetComponentInParent<FlowerPot>();

        if (flowerPot != currentPot)
            return;

        isInsideZone = false;

        currentGrab.selectExited.RemoveListener(OnPotReleased);

        currentPot = null;
        currentGrab = null;
    }

    private void OnPotReleased(SelectExitEventArgs args)
    {
        if (!isInsideZone)
            return;

        // On corrige uniquement la position et la rotation
        currentPot.transform.SetPositionAndRotation(
            potPlacement.position,
            potPlacement.rotation
        );

        Debug.Log("Pot aligned !");
    }
}