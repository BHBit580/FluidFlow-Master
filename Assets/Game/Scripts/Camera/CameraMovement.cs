using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float minY, maxY;
    [SerializeField] private float smoothTime = 0.125f;
    [SerializeField] private VoidEventChannelSO onCountDownFinished;
    [SerializeField] private GameObject water;

    private Vector3 _velocity;

    private void OnEnable() => onCountDownFinished.RegisterListener(MoveCameraToTheTop);

    private void Start() => water.SetActive(false);

    public void MoveCamera(Vector3 direction)
    {
        Vector3 targetPosition = transform.position + direction;
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
    }
    
    private void MoveCameraToTheTop()
    {
        Vector3 targetPosition = transform.position;
        targetPosition.y = maxY;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
        water.SetActive(true);
    }

    private void OnDisable() => onCountDownFinished.UnregisterListener(MoveCameraToTheTop);
}