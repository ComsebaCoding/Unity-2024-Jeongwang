using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingSystem : MonoBehaviour
{
    Vector3 TargetPosition;
    List<Vector3> EnemyPositionList;
    private void Update()
    {
        TargetChase();
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyPositionList.Add(other.gameObject.transform.position);
        }
        TargetChase();
    }


    private void TargetChase()
    {        
        float min_length = 12.0f;
        for (int i = 0; i < EnemyPositionList.Count; ++i)
        {
            Vector3 v = EnemyPositionList[i] - transform.position;
            float length = v.sqrMagnitude;
            if (min_length > length)
            {
                min_length = length;
                TargetPosition = v;
            }
        }
    }
    public Vector3 GetHomingTargetPosition()
    {
        TargetChase();
        return TargetPosition;
    }

    public bool isTarget()
    {
        return (EnemyPositionList.Count != 0);
    }
}
