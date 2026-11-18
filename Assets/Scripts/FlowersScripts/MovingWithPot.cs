using UnityEngine;

public class MovingWithPot : MonoBehaviour
{
    // Ce scripts est attacher aux prefab des plantes (graine, fleur...), Il permet au prefab de suivre le pot en temps reel.
    public GameObject seedPlacement;
    public GameObject[] PlantPrefab;


    private void Start()
    {
        //Instantiate(PlantPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
