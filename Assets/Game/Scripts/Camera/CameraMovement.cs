using System;
using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float minY, maxY;
    [SerializeField] private float smoothTime = 0.125f;
    [SerializeField] private float upTime = 0.5f;
    
    
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
        Vector3 targetPosition = new Vector3(transform.position.x, maxY, transform.position.z);
        StartCoroutine(SmoothMoveToTop(targetPosition, upTime));
    }

    private IEnumerator SmoothMoveToTop(Vector3 targetPosition, float time)
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
        
        //when camera reaches the top, it will activate the water particle system
        water.SetActive(true);
        
    }

    
    private void OnDisable() => onCountDownFinished.UnregisterListener(MoveCameraToTheTop);
}