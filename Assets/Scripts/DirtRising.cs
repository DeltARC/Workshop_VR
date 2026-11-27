using UnityEngine;

public class DirtFillVisual : MonoBehaviour
{
    [Header("Dirt Plane")]
    [SerializeField] private float maxHeight = 0.15f;
    [SerializeField] private Vector3 heightDirection = Vector3.up;

    private Vector3 initialLocalPosition;

    private void Awake()
    {
        // Remember the plane position configured in the scene.
        initialLocalPosition = transform.localPosition;
        SetFill01(0f);
    }

    public void SetFill01(float amount)
    {
        float fillAmount = Mathf.Clamp01(amount);

        // A fill level of zero hides the plane entirely.
        gameObject.SetActive(fillAmount > 0f);

        if (fillAmount <= 0f)
            return;

        // Raise the existing plane according to the fill level.
        Vector3 direction = heightDirection.sqrMagnitude > 0f
            ? heightDirection.normalized
            : Vector3.up;

        transform.localPosition =
            initialLocalPosition + direction * (maxHeight * fillAmount);
    }
}
