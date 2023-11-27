using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO levelFinished;
    [SerializeField] private Bucket bucket;
    [SerializeField] private TextMeshProUGUI gameOverText;

    private void Awake()
    {
        levelFinished.RegisterListener(OnAllChildren);
    }

    private void OnAllChildren()
    {
        gameOverText.text = bucket.waterAmount >= 50 ? "Bucket Filled !" : "Game Over !";
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
    public void OnClickReplyButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickNextLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    private void OnDisable()
    {
        levelFinished.UnregisterListener(OnAllChildren);
    }
}
