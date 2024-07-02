using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class End : MonoBehaviour
{
    public TextMeshProUGUI time;

    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI highScoreText;
    public GameObject endMenu;

    public float timer = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        endMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        float displayTime = Mathf.Round(timer);
        time.text = "Time Remaining: " + displayTime.ToString();

        if (timer <= 0.0f)
        {
            timerEnd();
        }
    }

    public void timerEnd()
    {
        Time.timeScale = 0.0f;
        endMenu.SetActive(true);

        int score = ScoreManager.instance.score;
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        pointsText.text = "Score: " + score.ToString() + " Points";
        highScoreText.text = "High Score: " + highScore.ToString() + " Points";
    }

    public void Setup(int score)
    {
        pointsText.text = score.ToString() + " Points";
        //highScoreText.text = highScore.ToString() + "Points";
    }

    public void Restart()
    {
        endMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        timer = 15.0f;


        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
