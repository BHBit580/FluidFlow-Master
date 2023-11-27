using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO levelFinished;
    [SerializeField] private Animator animator;
    [SerializeField] private float transitionTime = 1f;
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
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void OnClickNextLevelButton()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    
    IEnumerator LoadLevel(int levelIndex)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
    
    private void OnDisable()
    {
        levelFinished.UnregisterListener(OnAllChildren);
    }
}
