using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class FlowerPot : MonoBehaviour
{
    // Scripte dans FlowersPot, il indique ce qu'il y a dans le pot de fleur.
    private bool isTime = false;
    private bool isSun = false;
    private bool isWater = false;
    private bool isPottingSoils = false;
    public bool isSeed = false;

    [SerializeField] private GameObject WaterBall;

    void OnEnable()
    {
        WaitingTime.WaitingTimerStart += WaitingTimeEnd;
        Dirt.SeedPlanted += PlantedSeed;
    }

    void OnDisable()
    {
        WaitingTime.WaitingTimerStart -= WaitingTimeEnd;
        Dirt.SeedPlanted -= PlantedSeed;
    }

    void WaitingTimeEnd()
    {
        isTime = true;
        Debug.Log("FinTimer");
    }

    void PlantedSeed()
    {
        isSeed = true;
        Debug.Log("Perfect seed");
    }



}
