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

                // eulerAngle�� ���Ϸ� �����̴�. 0~360�� ������ ���� �����Ѵ�.
                float currentAngle = transform.rotation.eulerAngles.z;
                // SignedAngle �Լ��� ���ڷ� ���� �� ���� ������ ������ return�ϴ� �Լ�
                float targetAngle = Vector2.SignedAngle(Vector2.up, direction);
                float curVelocity = 0;
                // SmoothDampAngle �Լ��� �������ϰ� �ε巴�� ������ ������ return�ϴ� �Լ�
                // ref�� �� 3��° ���ڿ� ���� ȸ�� �ӵ��� �־ �����ش�.
                currentAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle,
                    ref curVelocity, speed * Time.deltaTime, 50000);
                // Quaternion.Euler �Լ��� ���ڷ� ���� ������ ���Ϸ� ������ ��ȯ�Ѵ�
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