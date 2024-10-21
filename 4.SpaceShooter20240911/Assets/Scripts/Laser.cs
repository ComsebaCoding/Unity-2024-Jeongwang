using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 5.0f;
    void Update()
    {
        // ������Ʈ�� ���� ȭ�� �߽����κ��� 15���� �־����� ������Ʈ�� ����
        if (transform.position.magnitude > 15.0f)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}