using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeGuard : MonoBehaviour
{
    public float durationTime = 5.0f; // 기본 지속시간
    public float increaseDurationTime = 4.5f;   // 먹었을 때 추가 지속시간
    float timer = 0.0f;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= durationTime)
        {
            Destroy(gameObject);
        }
    }
    public float GetRemainTime()
    {
        return durationTime - timer;
    }
}
