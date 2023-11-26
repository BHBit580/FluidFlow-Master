using System.Collections;
using UnityEngine;

public class RotatePipe : MonoBehaviour
{
    [SerializeField] private float rotationAngle = 90f;
    [SerializeField] private float rotationSpeed = 1f;

    private bool isRotating;
    private Quaternion targetRotation;

    public void Rotate()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateThePipe());
        }
    }

    IEnumerator RotateThePipe()
    {
        isRotating = true;

        Quaternion initialRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            transform.eulerAngles.z + rotationAngle
        );

        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime);
            elapsedTime += rotationSpeed * Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;

        isRotating = false;
    }
}