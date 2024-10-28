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

                // eulerAngle은 오일러 각도이다. 0~360도 사이의 값만 존재한다.
                float currentAngle = transform.rotation.eulerAngles.z;
                // SignedAngle 함수는 인자로 들어온 두 벡터 사이의 각도를 return하는 함수
                float targetAngle = Vector2.SignedAngle(Vector2.up, direction);
                float curVelocity = 0;
                // SmoothDampAngle 함수는 스무스하고 부드럽게 각도를 변경해 return하는 함수
                // ref로 들어간 3번째 인자에 현재 회전 속도를 넣어서 돌려준다.
                currentAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle,
                    ref curVelocity, speed * Time.deltaTime, 50000);
                // Quaternion.Euler 함수는 인자로 들어온 각도를 오일러 각도로 변환한다
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, currentAngle);
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