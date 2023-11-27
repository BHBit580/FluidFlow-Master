using UnityEngine;
using UnityEngine.EventSystems;

public class PipeBlocker : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject[] wayPoints;
    [SerializeField] private float speed = 2f;

    private bool isMoving = false;
    private int currentWayPointIndex = 0;

    private void Update()
    {
        if (isMoving)
        {
            MoveToWaypoint();
        }
    }

    private void MoveToWaypoint()
    {
        if (Vector2.Distance(wayPoints[currentWayPointIndex].transform.position, transform.position) > 0.2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWayPointIndex].transform.position,
                Time.deltaTime * speed);
        }
        else
        { 
            currentWayPointIndex++;
            if (currentWayPointIndex >= wayPoints.Length)
            {
                currentWayPointIndex = 0;
            }
            isMoving = false; 
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isMoving = !isMoving;
    }
}