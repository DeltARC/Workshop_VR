using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlantRecipe : MonoBehaviour
{
    private bool IsSeed = false;


    // Condition
    public MonoScript Water;
    public MonoScript Sun;
    public MonoScript Shadow;
    public MonoScript Fertilizer;


    //Check
    public bool[] NebuctalysCheck = new bool[4];
    public bool[] AzelioCheck = new bool[4];
    public bool[] BiollanteCheck = new bool[5];
    public bool[] LyseaCheck = new bool[5];
    public bool[] LillyCheck = new bool[5];
    public bool[] HeartyCheck = new bool[5];
    public bool[] YvisCheck = new bool[5];

    private bool[] SelectedCheck;

    //Recette
    private MonoScript[] Nebuctalys = new MonoScript[2];
    private MonoScript[] Azelio = new MonoScript[4];    
    private MonoScript[] Biollante = new MonoScript[5];
    private MonoScript[] Lysea = new MonoScript[5];
    private MonoScript[] Lilly = new MonoScript[3];
    private MonoScript[] Hearty = new MonoScript[7];
    private MonoScript[] Yvis = new MonoScript[3];


    private MonoScript[] Selected;

    private void Start()
    {
        NebSetup();
        AzeSetup();
        BioSetup();
        LysSetup();
        LilSetup();
        HeaSetup();
        YviSetup();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Seed>() && IsSeed == false)
        {
            if(other.GetComponent<Seed>().type == Seed.SeedType.Nebuctalys)
            {
                Selected = Nebuctalys;
                SelectedCheck = NebuctalysCheck;
                IsSeed = true;
            }
            else if(other.GetComponent<Seed>().type == Seed.SeedType.Azelio)
            {
                Selected = Azelio;
                SelectedCheck = AzelioCheck;
                IsSeed = true;
            }
            else if(other.GetComponent<Seed>().type == Seed.SeedType.Biollante)
            {
                Selected = Biollante;
                SelectedCheck = BiollanteCheck;
                IsSeed = true;
            }
            else if (other.GetComponent<Seed>().type == Seed.SeedType.Lysea)
            {
                Selected = Lysea;
                SelectedCheck = LyseaCheck;
                IsSeed = true;
            }
            else if (other.GetComponent<Seed>().type == Seed.SeedType.Lilly)
            {
                Selected = Lilly;
                SelectedCheck = LillyCheck;
                IsSeed = true;
            }
            else if (other.GetComponent<Seed>().type == Seed.SeedType.Hearty)
            {
                Selected = Hearty;
                SelectedCheck = HeartyCheck;
                IsSeed = true;
            }
            else if (other.GetComponent<Seed>().type == Seed.SeedType.Yvis)
            {
                Selected = Yvis;
                SelectedCheck = YvisCheck;
                IsSeed = true;
            }
        }
    }

    void NebSetup()
    {
        Nebuctalys[0] = Shadow;
        Nebuctalys[1] = Fertilizer;
        Nebuctalys[2] = Water;
    }
    void AzeSetup()
    {
        Azelio[0] = Sun;
        Azelio[1] = Water;
        Azelio[2] = Fertilizer;
        Azelio[3] = Water;
        Azelio[4] = Water;
    }

    void BioSetup()
    {
        Biollante[0] = Sun;
        Biollante[1] = null;
        Biollante[2] = Fertilizer;
        Biollante[3] = Fertilizer;
        Biollante[4] = null;
        Biollante[5] = Fertilizer;
    }

    void LysSetup()
    {
        Lysea[0] = Sun;
        Lysea[1] = null;
        Lysea[2] = Water;
        Lysea[3] = Shadow;
        Lysea[4] = Fertilizer;
        Lysea[5] = Sun;
    }

    void LilSetup()
    {
        Lilly[0] = Sun;
        Lilly[1] = Water;
        Lilly[2] = null;
        Lilly[3] = Fertilizer;
    }

    void HeaSetup()
    {
        Hearty[0] = Sun;
        Hearty[1] = Water;
        Hearty[2] = null;
        Hearty[3] = Fertilizer;
        Hearty[4] = Shadow;
        Hearty[5] = Water;
        Hearty[6] = null;
        Hearty[7] = Fertilizer;
    }

    void YviSetup()
    {
        Yvis[0] = Shadow;
        Yvis[1] = null;
        Yvis[2] = Water;
        Yvis[3] = Fertilizer;
    }

    void DoDelayAction(float delayTime)
    {
        StartCoroutine(DelayAction(delayTime));
    }

    IEnumerator DelayAction(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);

        //Do the action after the delay time has finished.
    }

}


