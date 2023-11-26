using TMPro;
using UnityEngine;


public class CountDownTimer : MonoBehaviour
{
    [SerializeField] private float timeToCountDown = 15f;
    [SerializeField] private VoidEventChannelSO onCountDownFinished;
    
    
    private TextMeshProUGUI textToDisplay;

    private void Start() => textToDisplay = GetComponent<TextMeshProUGUI>();

    void Update()
    {
        timeToCountDown -= Time.deltaTime;
        textToDisplay.text = Mathf.RoundToInt(timeToCountDown).ToString();

        if (timeToCountDown <= 0)
        {
            onCountDownFinished.RaiseEvent();
            gameObject.SetActive(false);
        }
    }
}
