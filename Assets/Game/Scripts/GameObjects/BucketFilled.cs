using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketFilled : MonoBehaviour
{
    [SerializeField] private float waitTime = 1.5f;
    [SerializeField] private VoidEventChannelSO levelFinished;
    
    private int maxWaterParticles = 50;
    private int currentWaterParticles = 0;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("WaterParticle"))
        {
            currentWaterParticles++;
            
            if(currentWaterParticles >= maxWaterParticles) Invoke(nameof(BucketFilledNowLevelFinished), waitTime);
        }
    }
    
    private void BucketFilledNowLevelFinished()
    {
        levelFinished.RaiseEvent();
        Debug.Log("BucketFilledNowLevelFinished");
    }
    
}
