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
                // ���� �ý��� ���� ���׸� ��ƾ� �մϴ�.
                Debug.Log("Ÿ���� �����Ѵ�!");
                OutDestroySelf();
                TargetPosition = homingSystem.GetHomingTargetPosition();
                Debug.Log("Ÿ����ġ:"+TargetPosition);
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