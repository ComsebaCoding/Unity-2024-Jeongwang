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
        // ������Ʈ�� ���� ȭ�� �߽����κ��� 15���� �־����� ������Ʈ�� ����
        if (transform.position.magnitude > 15.0f)
        {
            Destroy(gameObject);
        }
    }
    // ������ ó��
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
    // ���� �ı��Ǿ��� ��
    abstract protected void OnDead();

    public void Destruction()
    {
        OnDead();
        Destroy(gameObject);
    }
}
