using UnityEngine;

public class Door : MonoBehaviour
{
[Header("Door Settings")]
    [SerializeField] private Vector3 openOffset = new Vector3(0f, 3f, 0f);
    [SerializeField] private float speed = 2f;

    private Vector3 closedPosition;
    private Vector3 openPosition;

    private bool isOpen;

    private void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + openOffset;
    }

    private void Update()
    {
        Vector3 targetPosition = isOpen ? openPosition : closedPosition;

        transform.position = Vector3.MoveTowards(transform.position,targetPosition,speed * Time.deltaTime);
    }

    public void OpenDoor()
    {
        isOpen = true;
    }

    public void CloseDoor()
    {
        isOpen = false;
    }
}
