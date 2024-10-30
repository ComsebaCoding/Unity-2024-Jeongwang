using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingLaser : Laser
{
    public int HomingLaserDamage = 0;
    private HomingSystem[] homingSystems;

    private void Start()
    {
        homingSystems = GetComponentsInChildren<HomingSystem>();
    }

    protected void Update()
    {
        foreach (HomingSystem homingSystem in homingSystems)
        {
            GameObject target = homingSystem.GetHomingTarget();
            if (target)
            {
                OutDestroySelf();
                Vector3 direction = target.transform.position - transform.position;
                direction.Normalize();
                transform.Translate(direction * speed * Time.deltaTime, Space.World);

                // SignedAngle 함수는 인자로 들어온 두 벡터 사이의 각도를 return하는 함수
                float targetAngle = Vector2.SignedAngle(Vector2.up, direction);
                // Quaternion.Euler 함수는 인자로 들어온 각도를 오일러 각도로 변환한다
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, targetAngle);
            }
            else
            {
                base.Update();
            }
        }
        if (homingSystems.Length <= 0)
        {
            base.Update();
        }
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy e = other.gameObject.GetComponent<Enemy>();
            if (e != null)
            {
                e.hp = (HomingLaserDamage < e.hp) ? e.hp - HomingLaserDamage : 0;
                if (e.hp <= 0)
                    e.Destruction();
            }
        }
    }
}