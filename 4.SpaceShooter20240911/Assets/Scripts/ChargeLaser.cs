using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeLaser : Laser
{
    public int ChargeLaserDamage = 2;
    protected void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy e = other.gameObject.GetComponent<Enemy>();
            if (e != null)
            {
                // e.hp = (specialDamage > e.hp) ? 0 : e.hp - specialDamage;
                if (ChargeLaserDamage > e.hp)
                    e.hp = 0;
                else
                    e.hp -= ChargeLaserDamage;
                if (e.hp <= 0)
                    e.Destruction();
            }
        }
    }
}