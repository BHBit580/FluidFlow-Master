using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSimulation : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO startSimulation;
    [SerializeField] private GameObject upButton, downButton;
    
    public void OnClickStartSimulation()
    {
        startSimulation.RaiseEvent();
        upButton.SetActive(false);
        downButton.SetActive(false);
        gameObject.SetActive(false);
    }
}
