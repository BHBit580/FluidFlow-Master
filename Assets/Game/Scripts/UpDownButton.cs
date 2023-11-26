using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpDownButton : MonoBehaviour , IPointerUpHandler , IPointerDownHandler
{
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private float speed = 1f;
    private bool buttonPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }

    private void LateUpdate()
    {
        if (buttonPressed)
        {
            cameraMovement.MoveCamera(new Vector3(0 , speed , 0));
        }
    }
}
