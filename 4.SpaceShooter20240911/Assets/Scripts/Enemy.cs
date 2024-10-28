using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : MonoBehaviour
{
    public int hp;
    public AudioClip hitSound;

    // Update is called once per frame
    virtual protected void Update()
    {
        // 오브젝트가 게임 화면 중심으로부터 15보다 멀어지면 오브젝트를 제거
        if (transform.position.magnitude > 15.0f)
        {
            Destroy(gameObject);
        }
    }
    // 데미지 처리
    private void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.gameObject.CompareTag("AttackByPlayer"))
        {
            GameManager.instance.PlayOneShot(hitSound);
            --hp;
        }
        if (hp <= 0)
        {
            Destruction();
        }
    }
    // 적이 파괴되었을 때
    abstract protected void OnDead();

    public void Destruction()
    {
        OnDead();
        Destroy(gameObject);
    }
}
