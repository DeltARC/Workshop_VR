using UnityEditor;
using UnityEngine;

public class PlantRecipe : MonoBehaviour
{
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


    
    //Recette
    private MonoScript[] Nebuctalys = new MonoScript[3];
    private MonoScript[] Azelio = new MonoScript[3];    
    private MonoScript[] Biollante = new MonoScript[3];
    private MonoScript[] Lysea = new MonoScript[3];
    private MonoScript[] Lilly = new MonoScript[3];
    private MonoScript[] Hearty = new MonoScript[3];
    private MonoScript[] Yvis = new MonoScript[3];

    

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
