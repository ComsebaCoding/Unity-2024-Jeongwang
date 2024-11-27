using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeGuard : MonoBehaviour
{
    public float durationTime = 5.0f; // �⺻ ���ӽð�
    public float increaseDurationTime = 4.5f;   // �Ծ��� �� �߰� ���ӽð�
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
