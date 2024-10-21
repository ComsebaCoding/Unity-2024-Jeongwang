using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{
    Vector3 direction;
    void Start()
    {
        direction = Random.insideUnitCircle.normalized;
        transform.rotation = 
            Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
    }

    void Update()
    {
        transform.position += direction * Time.deltaTime;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
