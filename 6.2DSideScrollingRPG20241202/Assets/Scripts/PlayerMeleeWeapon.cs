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
            Debug.Log("플레이어의 근접무기 컴포넌트에서 조상 오브젝트 플레이어를 찾지 못했음");
        }
        // Rigidbody2D r = transform.GetComponentInParent<Rigidbody2D>();

        // 자식들 중 컴포넌트를 가진 녀석들을 최초로 찾아낸 걸 리턴
        // 만일 본인이 갖고 있는 컴포넌트면 본인걸 리턴
        // Rigidbody2D r = transform.GetComponentInChildren<Rigidbody2D>(); 

        if ((PlayerAnimator = Player.GetComponent<Animator>()) == null)
        {
            Debug.Log("플레이어 애니메이터가 없어요");
        }
        if ((PlayerStat = Player.GetComponent<PlayerStatus>()) == null)
        {
            Debug.Log("플레이어 스테이터스가 없어요");
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
                    Debug.Log("무기에 부딪힌 대상으로부터 적 스탯을 못 찾음");
                else
                    enemyStat.Damaged(PlayerStat.GetPhysicalAttack());
            }
        }
    }
}