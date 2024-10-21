using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // �� ũ�⿡ ���� ��ġ�� �����սô�.       
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