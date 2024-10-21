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
        direction = Random.insideUnitSphere; // 구형 형태로 랜덤한 방향 하나 뽑아옴
        direction.y = 0.0f; // y 방향 제거
        direction.Normalize(); // 정규화, 벡터의 크기를 1로 만듬
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
            Debug.Log("적이 가로벽에 충돌");
            direction.z = -direction.z;          
        }
        if (collision.gameObject.CompareTag("WallV"))
        {
            Debug.Log("적이 세로벽에 충돌");
            direction.x = -direction.x;         
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(transform.position + "적과 내가 부딪힘");
            Destroy(collision.gameObject);
        }
    }
}