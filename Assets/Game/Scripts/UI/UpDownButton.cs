using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class UpDownButton : MonoBehaviour , IPointerUpHandler , IPointerDownHandler
{ 
    [SerializeField] private CameraManager cameraManager;
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
            cameraManager.MoveCamera(new Vector3(0 , speed , 0));
        }
    }
}
