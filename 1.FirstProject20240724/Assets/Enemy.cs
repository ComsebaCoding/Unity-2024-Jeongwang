using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 direction;
    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        direction = Random.insideUnitSphere; // ���� ���·� ������ ���� �ϳ� �̾ƿ�
        direction.y = 0.0f; // y ���� ����
        direction.Normalize(); // ����ȭ, ������ ũ�⸦ 1�� ����
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * direction * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WallH"))
        {
            Debug.Log("���� ���κ��� �浹");
            direction.z = -direction.z;          
        }
        if (collision.gameObject.CompareTag("WallV"))
        {
            Debug.Log("���� ���κ��� �浹");
            direction.x = -direction.x;         
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(transform.position + "���� ���� �ε���");
            Destroy(collision.gameObject);
        }
    }
}