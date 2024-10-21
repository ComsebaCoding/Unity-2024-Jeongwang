using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Enemy
{
    private Rigidbody2D myRigid;
    public Vector3 direction = Vector3.zero;    // ���׿��� �̵� ����
    public float speed = 3.0f;                  // ���׿��� �ӷ�

    public GameObject ItemPrefab;
    public GameObject dustPrefab;

    // Start is called before the first frame update
    private void Start()
    {
        myRigid = gameObject.GetComponent<Rigidbody2D>();
        // ������Ʈ �����ϰ� ȸ����Ű��
        myRigid.angularVelocity = Random.Range(120.0f, 360.0f);

        // direction �� ���� 0 �� ���
        // ���׿��� �������� �÷��̾��� ������ direction ������ ����
        if (direction == Vector3.zero)
        {
    // �÷��̾� ��ġ ���� - ��� ��ġ ���� = ����� �÷��̾�� ���� ����
            Vector3 delta =
                GameManager.instance.player.transform.position
                - transform.position;   
            direction = delta.normalized;
        }
    }
    override protected void Update()
    {
        // Enemy �� Update�� ����
        base.Update();

        // direction �������� �̵�
        transform.position += direction * speed * Time.deltaTime;
    }
    protected override void OnDead()
    {
        for (int i = 0; i < 3; ++i)
            Instantiate(dustPrefab, transform.position, Quaternion.identity);

        if (Random.Range(0,10) < 3)
            Instantiate(ItemPrefab, transform.position, Quaternion.identity);
    }
}