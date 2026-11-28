
using UnityEngine;
using System.Collections;

public class ReactingPot : MonoBehaviour
{
    [Header("Pot State")]
    public bool IsFilledByDirt = false;
    private bool HasASeed = false;
    private bool isFilling = false;

    [Header("Dirt Layer")]
    [SerializeField] private GameObject DirtLayer;

    [Header("Fill Positions")]
    [SerializeField] private Transform bottomPoint;
    [SerializeField] private Transform topPoint;

    [Header("Dirt Scale")]
    [SerializeField] private float targetScaleX = 1f;
    [SerializeField] private float targetScaleZ = 1f;
    [SerializeField] private float fillDuration = 3f;

    private Vector3 initialScale;
    private Vector3 initialPosition;

    private void Start()
    {
        if (DirtLayer == null)
            return;

        initialScale = DirtLayer.transform.localScale;
        initialPosition = DirtLayer.transform.position;

        DirtLayer.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (IsFilledByDirt || isFilling)
            return;

        DirtBall dirtBall = other.GetComponent<DirtBall>();

        if (dirtBall)
        {
            Debug.Log("Pot rempli de terre !");

            Destroy(dirtBall.gameObject);

            StartCoroutine(FillDirt());
        }
    }

    private IEnumerator FillDirt()
    {
        isFilling = true;

        DirtLayer.SetActive(true);

        float elapsed = 0f;

        Vector3 startScale = DirtLayer.transform.localScale;

        Vector3 targetScale = new Vector3(
            targetScaleX,
            initialScale.y,
            targetScaleZ
        );

        Vector3 startPosition = bottomPoint.position;
        Vector3 targetPosition = topPoint.position;

        while (elapsed < fillDuration)
        {
            elapsed += Time.deltaTime;

            float progress = Mathf.Clamp01(elapsed / fillDuration);

            // Agrandissement horizontal
            DirtLayer.transform.localScale = Vector3.Lerp(
                startScale,
                targetScale,
                progress
            );

            // Montée du fond vers le haut du pot
            DirtLayer.transform.position = Vector3.Lerp(
                startPosition,
                targetPosition,
                progress
            );

            yield return null;
        }

        DirtLayer.transform.localScale = targetScale;
        DirtLayer.transform.position = targetPosition;

        IsFilledByDirt = true;
        isFilling = false;
    }
}
