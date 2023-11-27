using System.Collections;
using UnityEngine;


public class CameraManager : MonoBehaviour
{
    [Header("Values")] 
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float smoothTime = 0.125f;
    [SerializeField] private float upTime = 0.5f;
    [SerializeField] private float downSpeed= 2f;
    [SerializeField] private float downMovingDelay = 2f;
    
    
    [Header("GameObjects")]
    [SerializeField] private VoidEventChannelSO startSimulation;
    
    
    
    private Vector3 _velocity;

    private void OnEnable() => startSimulation.RegisterListener(MoveCameraToTheTop);
    

    public void MoveCamera(Vector3 direction)
    {
        Vector3 targetPosition = transform.position + direction;
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
    }
    
    private void MoveCameraToTheTop()
    {
        Vector3 targetPosition = new Vector3(transform.position.x, maxY, transform.position.z);
        StartCoroutine(SmoothMove(targetPosition, upTime));
    }

    private IEnumerator SmoothMove(Vector3 targetPosition, float time)
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = transform.position;

        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        CameraReachedTheTop();
    }
    
    private void MoveCameraToTheBottom()
    {
        Vector3 targetPosition = new Vector3(transform.position.x, minY, transform.position.z);
        StartCoroutine(SmoothMove(targetPosition, downSpeed));
    }

    private void CameraReachedTheTop()
    {
        Invoke(nameof(MoveCameraToTheBottom), downMovingDelay);         //Start Moving camera after after some second
    }

    
    private void OnDisable() => startSimulation.UnregisterListener(MoveCameraToTheTop);
}