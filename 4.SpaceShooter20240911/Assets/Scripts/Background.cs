using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Transform transPlayer;
    public float rate = 0.2f;

    // Update is called once per frame
    void Update()
    {
        transform.position = transPlayer.position * -rate;
    }
}
