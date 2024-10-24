using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 5.0f;
    protected void Update()
    {
        OutDestroySelf();
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
    }
    protected void OutDestroySelf()
    {
        // 오브젝트가 게임 화면 중심으로부터 15보다 멀어지면 오브젝트를 제거
        if (transform.position.magnitude > 15.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}