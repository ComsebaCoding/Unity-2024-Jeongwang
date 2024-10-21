using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Enemy
{
    private Rigidbody2D myRigid;
    public Vector3 direction = Vector3.zero;    // 메테오의 이동 방향
    public float speed = 3.0f;                  // 메테오의 속력

    public GameObject ItemPrefab;
    public GameObject dustPrefab;

    // Start is called before the first frame update
    private void Start()
    {
        myRigid = gameObject.GetComponent<Rigidbody2D>();
        // 오브젝트 랜덤하게 회전시키기
        myRigid.angularVelocity = Random.Range(120.0f, 360.0f);

        // direction 의 값이 0 일 경우
        // 메테오를 기준으로 플레이어의 방향을 direction 변수에 저장
        if (direction == Vector3.zero)
        {
    // 플레이어 위치 벡터 - 운석의 위치 벡터 = 운석에서 플레이어로 가는 방향
            Vector3 delta =
                GameManager.instance.player.transform.position
                - transform.position;   
            direction = delta.normalized;
        }
    }
    override protected void Update()
    {
        // Enemy 의 Update를 실행
        base.Update();

        // direction 방향으로 이동
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