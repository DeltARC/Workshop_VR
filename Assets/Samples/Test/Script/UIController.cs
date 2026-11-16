using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreTest;

    private void Start()
    {
    }
    public void UpdateScoreText(int scoreValue)
    {
        scoreTest.text = scoreValue.ToString();
    }
}

