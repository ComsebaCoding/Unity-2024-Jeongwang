using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingLaser : Laser
{
    public int HomingLaserDamage = 0;
    Vector3 TargetPosition;
    public GameObject HomingRange;
    private HomingSystem homingSystem;

    private void Start()
    {
        if (HomingRange == null)
            homingSystem = HomingRange.GetComponent<HomingSystem>();
    }

    protected void Update()
    {
        if (homingSystem != null)
        {
            if (homingSystem.isTarget())
            {
                // 유도 시스템 관련 버그를 잡아야 합니다.
                Debug.Log("타겟이 존재한다!");
                OutDestroySelf();
                TargetPosition = homingSystem.GetHomingTargetPosition();
                Debug.Log("타겟위치:"+TargetPosition);
                Vector3 direction = TargetPosition - transform.position;
                transform.Translate(direction * speed * Time.deltaTime, Space.World);
            }
            else
            {
                base.Update();
            }
        }
        else
        {
            base.Update();
        }
    }
}