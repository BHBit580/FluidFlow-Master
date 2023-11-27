using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO startSimulation;
    [SerializeField] private GameObject waterParentPrefab;

    private void Awake() => startSimulation.RegisterListener(SpawnWater);
    
    private void SpawnWater()
    {
        GameObject waterParent = Instantiate(waterParentPrefab, transform.position, Quaternion.identity);
        waterParent.transform.SetParent(transform);
    }

    private void OnDisable() => startSimulation.UnregisterListener(SpawnWater);
}
