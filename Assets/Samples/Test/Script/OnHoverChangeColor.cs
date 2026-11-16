using UnityEngine;
using System.Collections;

public class OnHoverChangeColor : MonoBehaviour
{
    [SerializeField] private Material newMaterial;
    [SerializeField] private Material originalMaterial;
 public void ChangeMaterialOnHover(Material newMaterial)
    {
        originalMaterial = GetComponent<MeshRenderer>().material;
        GetComponent<MeshRenderer>().material = newMaterial;
    }
}