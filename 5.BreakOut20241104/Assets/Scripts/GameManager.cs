using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public int hp = 5;
    public float ballSpeed = 3.0f;

    public Ball ballPrefab;     // origin ball info
    public List<Ball> balls;    // now, in game ball
}