using UnityEngine;
using UnityEngine.Rendering;

public class RespawnZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        RespawnableObject respawnObject = other.GetComponent<RespawnableObject>();
        Debug.Log("Touch " + other);

        if (respawnObject)
        {
            respawnObject.Respawning();
        }
    }
}
