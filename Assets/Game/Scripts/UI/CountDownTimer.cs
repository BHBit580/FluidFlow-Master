using System.Collections;
using TMPro;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] private float maxTime = 5;
    [SerializeField] private VoidEventChannelSO startSimulation;
    [SerializeField] private VoidEventChannelSO levelFinished;

    private TextMeshProUGUI uiText;

    private void Awake()
    {
        startSimulation.RegisterListener(StartCounting);
        uiText = GetComponent<TextMeshProUGUI>();
        uiText.text = null;
    }
    
    private void StartCounting()
    {
        StartCoroutine(GameTimer());
    }
    
    IEnumerator GameTimer()
    {
        float currentTime = maxTime;
        while (currentTime >=0)
        {
            uiText.text = Mathf.RoundToInt(currentTime).ToString();
            currentTime -= Time.deltaTime;
            yield return null;
        }

        uiText.text = null;
        levelFinished.RaiseEvent();
    }
    
    private void OnDisable()
    {
        startSimulation.UnregisterListener(StartCounting);
    }
}