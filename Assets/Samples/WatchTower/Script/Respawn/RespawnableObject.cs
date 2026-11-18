using UnityEngine;

public class RespawnableObject : MonoBehaviour
{
    public Vector3 SpawnLocation;

    void Start()
    {
        SpawnLocation = transform.position;
        Debug.Log("Saved " + gameObject + " to " + SpawnLocation);
    }

    public void Respawning()
    {
        gameObject.transform.position = SpawnLocation;
        Debug.Log("Respawn " + gameObject + " : " + gameObject.transform.position);
    }
}