using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public int Life = 5;
    public float BallSpeedScale = 1.0f;

    public Ball ballPrefab;     // origin ball info
    public List<Ball> balls;    // now, in game ball

    public GameObject GameOverUI;

    public Image LifeUIPrefab;
    public List<Image> LifeList;

    private void Start()
    {
        Time.timeScale = 1.0f;
        GameOverUI.SetActive(false);


        for (int i = 1; i <= Life; ++i)
        {
            LifeList.Add(Instantiate<Image>(LifeUIPrefab,
                Vector3.zero, Quaternion.identity, 
                GameObject.Find("Canvas").transform));
            LifeList[i-1].rectTransform.anchoredPosition = 
                new Vector3(-275.0f + (i * 100.0f), 485.0f);
        }
    }

    public void Damage(int damage = 1)
    {
        if (damage < 0)
        {
            Debug.Log("damage is 0. are you serious?");
            return;
        }
        for (int i = 0; i < damage; ++i)
        {
            --Life;
            Image delImage = LifeList[Life];
            LifeList.RemoveAt(Life);
            Destroy(delImage.gameObject);
            if (Life <= 0)
            {
                GameOver();
            }
        }     
    }

    public void Heal(int heal = 1)
    {
        if (heal < 0)
        {
            Debug.Log("minus healing. are you serious?");
            return;
        }
        for (int i = 0; i < heal; ++i)
        {
            ++Life;
            LifeList.Add(Instantiate<Image>(LifeUIPrefab,
                Vector3.zero, Quaternion.identity,
                GameObject.Find("Canvas").transform));
            LifeList[Life - 1].rectTransform.anchoredPosition =
                new Vector3(-275.0f + (Life * 100.0f), 485.0f);
        }
    }

    public void GameOver()
    {
        // 게임 오버 UI 발생 및 재시작 버튼 생성
        Time.timeScale = 0.0f;
        GameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        // Scene을 재시작하는 함수
        SceneManager.LoadScene(0);
    }

    private void OnDestroy()
    {
        instance = null;
    }
}