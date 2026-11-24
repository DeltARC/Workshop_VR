using UnityEngine;

public class PlantGrowthController : MonoBehaviour
{
    [Header("Plant Recipe")]
    [SerializeField] private PlantRecipe recipe;

    private int currentStageIndex = 0;
    private int currentStepIndex = 0;

    private PlantStage CurrentStage
    {
        get
        {
            if (recipe == null || currentStageIndex >= recipe.stages.Count)
                return null;

            return recipe.stages[currentStageIndex];
        }
    }

    private PlantStep CurrentStep
    {
        get
        {
            if (CurrentStage == null ||
                currentStepIndex >= CurrentStage.steps.Count)
                return null;

            return CurrentStage.steps[currentStepIndex];
        }
    }

    private void CompleteCurrentStep()
    {
        if (CurrentStep == null)
            return;

        currentStepIndex++;

        // Vérifier si toutes les tâches du stade sont terminées
        if (currentStepIndex >= CurrentStage.steps.Count)
        {
            currentStageIndex++;
            currentStepIndex = 0;

            if (CurrentStage == null)
            {
                Debug.Log("Croissance de la plante terminée !");
                return;
            }

            Debug.Log("Nouveau stade : " + CurrentStage.stageName);
        }

        if (CurrentStep != null)
        {
            Debug.Log("Prochaine tâche : " + CurrentStep.stepType);
        }
    }

    public void WaterPlant()
    {
        if (CurrentStep == null)
            return;

        if (CurrentStep.stepType != PlantStepType.Water)
            return;

        Debug.Log("Plante arrosée !");
        CompleteCurrentStep();
    }

}
