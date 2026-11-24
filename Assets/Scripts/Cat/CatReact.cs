using UnityEngine;

public class CatReact : MonoBehaviour
{
    [SerializeField] private GameObject CatCollisiion;
    AudioSource AngryCat;
    

    private void Start()
    {
        AngryCat = GetComponent<AudioSource>();
    }

    public void OnColliderEnter(Collider other)
    {
        Objects objects = other.GetComponent<Objects>();

        if (objects)
        {
            Debug.Log("hit");
            GetComponent<AudioSource>().Play();
        }
    }
}
