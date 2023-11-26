using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float minY, maxY;
    [SerializeField] private float smoothTime = 0.125f;

    private Vector3 _velocity;

    public void MoveCamera(Vector3 direction)
    {
        Vector3 targetPosition = transform.position + direction;
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
    }
}