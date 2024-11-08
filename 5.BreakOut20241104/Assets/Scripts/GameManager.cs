using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Image LifeUIPrefab;
    public List<Image> LifeList;

    private void Start()
    {
        for (int i = 1; i <= Life; ++i)
        {
            LifeList.Add(Instantiate<Image>(LifeUIPrefab,
                Vector3.zero, Quaternion.identity, 
                GameObject.Find("Canvas").transform));
            LifeList[i-1].rectTransform.anchoredPosition = 
                new Vector3(-275.0f + (i * 100.0f), 485.0f);
        }
    }

    public void Damage()
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

    public void Heal()
    {
        ++Life;
        LifeList.Add(Instantiate<Image>(LifeUIPrefab,
            Vector3.zero, Quaternion.identity, 
            GameObject.Find("Canvas").transform));
        LifeList[Life-1].rectTransform.anchoredPosition = 
            new Vector3(-275.0f + (Life * 100.0f), 485.0f);
    }

    public void GameOver()
    {
        // ���� ���� UI �߻� �� ����� ��ư ����
    }

    public void RestartGame()
    {
        // Scene�� ������ϴ� �Լ�
    }

    private void OnDestroy()
    {
        instance = null;
    }
}