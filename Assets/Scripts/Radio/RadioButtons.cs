
using UnityEngine;

public class RadioButtons : MonoBehaviour
{
    [Header("Radio")]
    [SerializeField] private RadioController radio;
    [SerializeField] private bool nextButton;

    [Header("Button Animation")]
    [SerializeField] private Transform buttonVisual;
    [SerializeField] private Vector3 pressDirection = Vector3.back;
    [SerializeField] private float pressDistance = 0.02f;
    [SerializeField] private float returnSpeed = 15f;

    private Vector3 initialPosition;
    private Vector3 targetPosition;

    private bool isPressed;

    private void Awake()
    {
        if (buttonVisual == null)
            buttonVisual = transform;

        initialPosition = buttonVisual.localPosition;
        targetPosition = initialPosition;
    }

    private void Update()
    {
        buttonVisual.localPosition = Vector3.Lerp(
            buttonVisual.localPosition,
            targetPosition,
            Time.deltaTime * returnSpeed
        );
    }

    public void Press()
    {
        if (isPressed)
            return;

        isPressed = true;

        targetPosition = initialPosition
            + pressDirection.normalized * pressDistance;

        if (radio == null)
        {
            Debug.LogWarning("RadioController manquant !");
            return;
        }

        if (nextButton)
        {
            radio.NextTrack();
        }
        else
        {
            radio.PreviousTrack();
        }
    }

    public void Release()
    {
        isPressed = false;
        targetPosition = initialPosition;
    }
}
