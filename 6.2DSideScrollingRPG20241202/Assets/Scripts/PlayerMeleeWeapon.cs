using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeWeapon : MonoBehaviour
{
    GameObject Player;
    PlayerStatus PlayerStat;
    Animator PlayerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        Transform temptransform = transform.parent;
        while( !temptransform.gameObject.CompareTag("Player"))
        {
            temptransform = temptransform.parent;
        }
        if (temptransform)
        {           
            Player = temptransform.gameObject;
        }
        else
        {
            Debug.Log("�÷��̾��� �������� ������Ʈ���� ���� ������Ʈ �÷��̾ ã�� ������");
        }
        // Rigidbody2D r = transform.GetComponentInParent<Rigidbody2D>();

        // �ڽĵ� �� ������Ʈ�� ���� �༮���� ���ʷ� ã�Ƴ� �� ����
        // ���� ������ ���� �ִ� ������Ʈ�� ���ΰ� ����
        // Rigidbody2D r = transform.GetComponentInChildren<Rigidbody2D>(); 

        if ((PlayerAnimator = Player.GetComponent<Animator>()) == null)
        {
            Debug.Log("�÷��̾� �ִϸ����Ͱ� �����");
        }
        if ((PlayerStat = Player.GetComponent<PlayerStatus>()) == null)
        {
            Debug.Log("�÷��̾� �������ͽ��� �����");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (PlayerAnimator.GetBool("isAttack"))
        {
            if (other.gameObject.CompareTag("Monster"))
            {
                MonsterStatus enemyStat = other.gameObject.GetComponent<MonsterStatus>();
                if (enemyStat == null)
                    Debug.Log("���⿡ �ε��� ������κ��� �� ������ �� ã��");
                else
                    enemyStat.Damaged(PlayerStat.GetPhysicalAttack());
            }
        }
    }
}