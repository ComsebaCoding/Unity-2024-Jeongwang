using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // 맵 크기에 따라 수치를 변경합시다.       
        Vector3 nextPosition = new Vector3(
            Random.Range(-8f, 8f),
            1.0f,
            Random.Range(-8f, 8f));
        transform.position = nextPosition;

        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.score += 10;
        }
    }
}