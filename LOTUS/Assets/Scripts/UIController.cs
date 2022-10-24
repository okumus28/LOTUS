using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    public GameObject panel;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI helpText;
    public Button reStartButton;
    public Button nextLevelButton;

    private void Awake()
    {
        Instance = this;
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void NextLevelButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Victory()
    {
        panel.SetActive(true);
        gameOverText.text = "VICTORY";
        helpText.text = "AMAZING!";

        reStartButton.gameObject.SetActive(false);
        nextLevelButton.gameObject.SetActive(true);
    }
    
    public void GameOver()
    {
        panel.SetActive(true);
        gameOverText.text = "GAME OVER";
        helpText.text = "TRY AGAIN!";

        reStartButton.gameObject.SetActive(true);
        nextLevelButton.gameObject.SetActive(false);
    }
}
