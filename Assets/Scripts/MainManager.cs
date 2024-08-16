using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public bool isGameActive;
    public int score = 0;
    public TextMeshProUGUI GameOverText, ScoreText, FinalScoreText;
    public Button RestartButton, ExitButton;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameActive = false;
        FinalScoreText.text = "Your score: " + score;
        GameOverText.gameObject.SetActive(true);
        FinalScoreText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        ExitButton.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
