using UnityEngine;
using System.Collections;

public class CatReact : MonoBehaviour
{
    [SerializeField] private GameObject CatCollisiion;
    AudioSource AngryCat;
    

    private void Start()
    {
        AngryCat = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        Objects objects = other.GetComponent<Objects>();

        if (objects)
        {
            Debug.Log("hit");
            GetComponent<AudioSource>().Play();
        }
    }
}
