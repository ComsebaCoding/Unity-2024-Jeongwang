using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : Enemy
{
    public float speed = 3.0f;
    public float chaseRange = 7.5f;

    private float EnemyAttackTimer = 0.0f;
    public float EnemyAttackCoolTime = 1.0f;

    public GameObject EnemyAttackPrefab;
    // GameManager.instance.player;
    // Start is called before the first frame update
    void Start()
    {            
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        Vector3 direction =
            GameManager.instance.player.transform.position - transform.position;
        direction.Normalize();
        if (Vector3.Distance(transform.position
            , GameManager.instance.player.transform.position) > chaseRange)
        {
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
        else
        {
            EnemyAttackTimer += Time.deltaTime;            
            if (EnemyAttackTimer >= EnemyAttackCoolTime)
            {
                EnemyAttackTimer -= EnemyAttackCoolTime;
                float targetAngle = Vector2.SignedAngle(Vector2.up, direction);
                Instantiate(EnemyAttackPrefab, 
                    transform.position, Quaternion.Euler(0.0f, 0.0f, targetAngle));               
                //Instantiate(EnemyAttackPrefab,transform.position, Quaternion.LookRotation(direction));
            }
        }
    }

    protected override void OnDead()
    {
        // Animation, Dust¹ß»ý
        GameManager.instance.Score += 10;
    }
}