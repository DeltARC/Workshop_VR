using UnityEngine;

public class WaitingTime : MonoBehaviour
{
    // Ce script est attacher au pot, il inque le temps.
    [SerializeField] private bool seedActive = false;
    [SerializeField] private bool activeTimer = false;
    [SerializeField] private float waitingTime = 0f;

    public delegate void WaitingTimeStart();
    public static event WaitingTimeStart WaitingTimerStart;

    public GameObject FlowerPot;
    bool isSeeds;

    private void Start()
    {
        activeTimer = true;
    }

    void FixedUpdate()
    {
        if (FlowerPot.GetComponent<FlowerPot>().isSeed)
        {
            Debug.Log("true seed");
            if (seedActive)
            {
                if (activeTimer)
                {
                    waitingTime += Time.deltaTime;

                    if (waitingTime > 5f)
                    {
                        Debug.Log("5 seconde");
                        WaitingTimerStart?.Invoke();
                        activeTimer = false;
                    }
                }
            }
        }
    }
}
