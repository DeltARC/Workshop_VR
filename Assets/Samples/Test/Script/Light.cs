using UnityEngine;

public class Light : MonoBehaviour
{
    [SerializeField] private bool lightState = false;
    [SerializeField] private Material MaterialOn;
    [SerializeField] private Material MaterialOff;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLeverDown()
    {
        lightState = !lightState;
        if (lightState == false)
        {
            GetComponent<Light>().enabled = true;
            GetComponent<Renderer>().material = MaterialOn;
        }
        else
        {
            GetComponent<Light>().enabled = false;
            GetComponent<Renderer>().material = MaterialOff;
        }            
    }
}
