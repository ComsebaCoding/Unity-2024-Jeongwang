using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : MonoBehaviour
{
    public int hp;
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
        --hp;
        if (hp <= 0)
        {
            OnDead();
            Destroy(gameObject);
        }
    }
    // ���� �ı��Ǿ��� ��
    abstract protected void OnDead();
}
