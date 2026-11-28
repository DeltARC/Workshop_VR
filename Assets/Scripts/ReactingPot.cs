using UnityEngine;

public class ReactingPot : MonoBehaviour
{
    public bool IsFilledByDirt = false;
    private bool HasASeed = false;

    [SerializeField] private GameObject DirtLayer;
    
    public void OnTriggerEnter(Collider other)
    {
        DirtBall dirtBall = other.GetComponent<DirtBall>();
        if (dirtBall)
        {
            Debug.Log("Pot rempli de terre !");

            DirtFillVisual dirtVisual = DirtLayer.GetComponent<DirtFillVisual>();
            if (dirtVisual != null)
                dirtVisual.SetFill01(1f);
            else
                DirtLayer.SetActive(true);

            IsFilledByDirt = true;
            Destroy(dirtBall.gameObject);
        }
    }
}