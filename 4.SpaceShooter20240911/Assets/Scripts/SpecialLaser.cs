using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialLaser : Laser
{
    public int specialDamage = 3;
    protected void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy e = other.gameObject.GetComponent<Enemy>();
            if (e != null)
            {
                // e.hp = (specialDamage > e.hp) ? 0 : e.hp - specialDamage;
                if (specialDamage > e.hp)
                    e.hp = 0;
                else
                    e.hp -= specialDamage;
                if (e.hp <= 0)
                    e.Destruction();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적에 닿아도 안 사라지기 위해 상속받지 않고 내용 없는 함수 재작성
    }
}