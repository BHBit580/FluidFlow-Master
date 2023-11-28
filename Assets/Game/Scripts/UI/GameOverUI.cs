using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO levelFinished;
    [SerializeField] private GameObject nextButton, homeButton;
    [SerializeField] private Animator animator;
    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private Bucket bucket;
    [SerializeField] private TextMeshProUGUI gameOverText;

    private void Awake()
    {
        levelFinished.RegisterListener(UpdateGameOverUIVisibility);
    }

    private void UpdateGameOverUIVisibility()
    {
        gameOverText.text = bucket.waterAmount >= 50 ? "Bucket Filled !" : "Try Again !";

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        bool isLastLevel = currentSceneIndex == SceneManager.sceneCountInBuildSettings - 1;

        foreach (Transform child in transform)
        {
            if (child.gameObject == homeButton)
            {
                homeButton.SetActive(isLastLevel);
                nextButton.SetActive(!isLastLevel);
            }
            else if (child.gameObject == nextButton)
            {
                nextButton.SetActive(!isLastLevel);
                homeButton.SetActive(isLastLevel);
            }
            else
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    public void OnClickReplyButton()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void OnClickNextLevelButton()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    
    public void OnClickHomeButton()
    {
        StartCoroutine(LoadLevel(0));
    }
    
    IEnumerator LoadLevel(int levelIndex)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    private void OnDisable()
    {
        levelFinished.UnregisterListener(UpdateGameOverUIVisibility);
    }
}
