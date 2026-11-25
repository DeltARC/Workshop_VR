using NUnit.Framework;
using UnityEngine;

public class Azelio : MonoBehaviour
{
    public bool isSeedPlanted;
    public int growthStage; // 0 = seed, 1 = sprout, 2 = big sprout, 3 = mature
    private bool isWatered;
    private bool isFertilized;
    public bool isSunlight;
    public bool isShadowed;
    private bool isTimePassed;
    private float timer = 0f;

    [Header("Stage Models")]
    [SerializeField] private GameObject seedModel;
    [SerializeField] private GameObject sproutModel;
    [SerializeField] private GameObject bigSproutModel;
    [SerializeField] private GameObject matureModel;

    void Start()
    {
        isSeedPlanted = true;
        growthStage = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (growthStage == 0)
        {
            GrowStage1();
        }
        else if (growthStage == 1)
        {
            GrowStage2();
        }
        else if (growthStage == 2)
        {
            GrowStage3();
        }
        else if (growthStage == 3)
        {
            MaxStageReached();
            Debug.Log("Plante mature !");
        }
    }

    void FixedUpdate()
    {
        if (timer<20000)
        {
        timer = timer + 1;
        }
        else
        {
            isTimePassed = true;
        }
    }

    public void PlantSeed()
    {
        isSeedPlanted = true;
        growthStage = 0;
    }

    public void OnTriggerEnter(Collider other)
    {
        WaterBall waterBall = other.GetComponent<WaterBall>();
        if (waterBall)
        {
            Debug.Log("Plante arrosee !");
            isWatered = true;
            Destroy(waterBall.gameObject);
        }

        FertilizerBall fertilizerBall = other.GetComponent<FertilizerBall>();
        if (fertilizerBall)
        {
            Debug.Log("Plante fertilisee !");
            isFertilized = true;
            Destroy(fertilizerBall.gameObject);
        }
        Sun sun = other.GetComponent<Sun>();
        if (sun)
        {
            Debug.Log("Plante au soleil");
            isSunlight = true;
        }
        Shadow shadow = other.GetComponent<Shadow>();
        if (shadow)
        {
            Debug.Log("Plante à l'ombre");
            isShadowed = true;
        }        
    }

    private void WaterPlant()
    {
        isWatered = true;
    }

    private void FertilizePlant()
    {
        isFertilized = true;
    }

    private void StageCompleted()
    {
        isWatered = false;
        isFertilized = false;
        isSunlight = false;
        isShadowed = false;
        isTimePassed = false;
        growthStage++;
    }

    private void GrowStage1()
    {
        if (isSeedPlanted && isSunlight)
        {
            if (isWatered)
            {
                StageCompleted();
                seedModel.SetActive(false);
                sproutModel.SetActive(true);
            }
        }
    }

    private void GrowStage2()
    {
        if (isWatered)
        {
            if (isSunlight)
            {
                StageCompleted();
                sproutModel.SetActive(false);
                bigSproutModel.SetActive(true);
            }
        }
    }

    private void GrowStage3()
    {
        if (isWatered)
        {
            if (isSunlight)
            {
                StageCompleted();
                bigSproutModel.SetActive(false);
                matureModel.SetActive(true);
            }
        }
    }

    private void MaxStageReached()
    {
        // La plante est maintenant mature et ne peut plus pousser.
    }
}
