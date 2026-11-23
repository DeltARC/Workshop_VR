using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlantStep
{
    public PlantStepType stepType;

    [Header("Light Settings")]
    public PlantLightRequirement lightRequirement;
    public float lightDuration = 5f;

    [Header("Wait Settings")]
    public float waitDuration = 30f;
}

[Serializable]
public class PlantStage
{
    public string stageName;

    public List<PlantStep> steps = new List<PlantStep>();
}

[CreateAssetMenu(
    fileName = "New Plant Recipe",
    menuName = "Plants/Plant Recipe"
)]
public class PlantRecipe : ScriptableObject
{
    public string plantName;

    public List<PlantStage> stages = new List<PlantStage>();
}
