using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip clickSound;
    public GameObject gameStartUi;
    public GameObject gameOverUi;
    public static int score;
    public Text scoreLabel;
    public int highScore;
    public Text highscoreLabel;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        Time.timeScale = 0.0f;
        gameStartUi.SetActive(true);
        score = 0;
        highScore = PlayerPrefs.GetInt("highScore", 0);
        highscoreLabel.text = "HighScore : " + highScore.ToString("D5");
    }
    public void GameStart()
    {
        Time.timeScale = 1.0f;
        gameStartUi.SetActive(false);
        audioSource.PlayOneShot(clickSound);
    }
    public void GameOver()
    {
        Time.timeScale = 0.0f;
        gameOverUi.SetActive(true);
        if (score > highScore)
            PlayerPrefs.SetInt("highScore", score);
        audioSource.PlayOneShot(clickSound);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("highScore", 0);
        highScore = 0;
    }


    private float score_timer = 0.0f;
    public float time_score_border = 10.0f;
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0.0f)
        {
            score_timer += Time.deltaTime;
        }
        if (score_timer > time_score_border)
        {
            ++score;
            score_timer -= time_score_border;
        }
        scoreLabel.text = "SCORE : " + score.ToString("D5");
    }
}
