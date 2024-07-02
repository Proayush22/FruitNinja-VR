using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.AI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] TextMeshPro startText;
    [SerializeField] TextMeshPro scoreText;
    [SerializeField] TextMeshPro livesText;
    [SerializeField] TextMeshPro highScoreText1;
    [SerializeField] TextMeshPro highScoreText2;
    [SerializeField] TextMeshPro highScoreText3;
    [SerializeField] TextMeshPro newHighScore;
    [SerializeField] AudioClip audioClip;

    public int score;
    public int lives;
    public int highScore;

    public float Timer = 0;
    public float Timer2 = 0;

    //public TextMeshProGUI score;

    // Start is called before the first frame update
    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        lives = 3;
        //scoreText.text = "Score: " + score.ToString();
        //livesText.text = lives.ToString() + " Lives";
        scoreText.text = " ";
        livesText.text = " ";

        highScoreText1.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        highScoreText2.text = "High Score: " + PlayerPrefs.GetInt("HighScore1", 0).ToString();
        highScoreText3.text = "High Score: " + PlayerPrefs.GetInt("HighScore2", 0).ToString();

    }
    void Update()
    {
        Timer += Time.deltaTime;
        Timer2 += Time.deltaTime;
    }
    public void AddPoint()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
        //checkHS();
    }

    public void startGame()
    {
        startText.text = "";
        highScoreText1.text = "";
        highScoreText2.text = "";
        highScoreText3.text = "";

        scoreText.text = "Score: " + score.ToString();
        livesText.text = lives.ToString() + " Lives";
    }

    public void loseLife()
    {
        lives--;
        livesText.text = lives.ToString() + " Lives";
        if(lives == 0)
        {
            //scoreText.SetActive(false);
            //livesText.setActive(false);
            scoreText.enabled = false;
            livesText.enabled = false;

            highScoreText1.text = "High Score 1: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
            highScoreText2.text = "High Score 2: " + PlayerPrefs.GetInt("HighScore1", 0).ToString();
            highScoreText3.text = "High Score 3: " + PlayerPrefs.GetInt("HighScore2", 0).ToString();

            UnityEngine.SceneManagement.SceneManager.LoadScene("Classic");

        }
    }
    void checkHS()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            highScore = score;
            int oldHS = PlayerPrefs.GetInt("HighScore", 0);
            int oldHS1 = PlayerPrefs.GetInt("HighScore1", 0);
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.SetInt("HighScore1", oldHS);
            PlayerPrefs.SetInt("HighScore2", oldHS1);
            AudioSource.PlayClipAtPoint(audioClip, transform.position, 1f);
            //highScoreText.text = "High Score: " + highScore.ToString();
            newHighScore.text = "New High Score!";
        }
        else if (score > PlayerPrefs.GetInt("HighScore1", 0))
        {
            newHighScore.text = "New High Score!";
            int oldHS = PlayerPrefs.GetInt("HighScore1", 0);
            PlayerPrefs.SetInt("HighScore1", score);
            PlayerPrefs.SetInt("HighScore2", oldHS);

            AudioSource.PlayClipAtPoint(audioClip, transform.position, 1f);
            newHighScore.text = "New High Score!";
        }
        else if (score > PlayerPrefs.GetInt("HighScore2", 0))
        {
            newHighScore.text = "New High Score!";
            PlayerPrefs.SetInt("HighScore2", score);

            AudioSource.PlayClipAtPoint(audioClip, transform.position, 1f);
            newHighScore.text = "New High Score!";
        }
    }
}
