using UnityEngine;

public class SeedDetect : MonoBehaviour
{

    public bool Isplant = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject);

        if(other.gameObject.GetComponent<Seed>())
        {
            Debug.Log(other.gameObject.GetComponent<Seed>().type);
            Isplant = true;
        }
        
    }
}
