using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingSystem : MonoBehaviour
{
    public GameObject Target;
    public List<GameObject> EnemyList;
    private void Update()
    {
        TargetSetting();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyList.Add(other.gameObject);
        }
        TargetSetting();
    }

    private void TargetSetting()
    {        
        float min_length = 20.0f;
        foreach (GameObject enemy in EnemyList)
        {
            float length = Vector3.Distance(transform.position, enemy.transform.position);
            if (min_length > length)
            {
                min_length = length;
                Target = enemy;
            }
        }
    }

    public GameObject GetHomingTarget()
    {
        TargetSetting();
        return Target;
    }
}
