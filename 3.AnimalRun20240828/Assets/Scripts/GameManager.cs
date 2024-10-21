using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    AudioSource audioSource;
    public AudioClip clickSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        Time.timeScale = 1.0f;    
    }
    public void GameOver()
    {
        Time.timeScale = 0.0f;
        gameOverUI.SetActive(true);
    }
    public void RestartGame()
    {
        audioSource.PlayOneShot(clickSound);
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
