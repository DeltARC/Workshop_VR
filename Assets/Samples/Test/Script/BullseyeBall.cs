using UnityEngine;

public class BullseyeBall : MonoBehaviour
{

    [SerializeField] private ScoreDatas scoreData;
    [SerializeField] private UIController uiController;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        AimTarget Target = other.gameObject.GetComponent<AimTarget>();
        if (Target)
        {
            scoreData.Score = scoreData.Score + Target.scoreValue;
            Debug.Log(scoreData.Score);
            uiController.UpdateScoreText(scoreData.Score);
        }
    }
}
