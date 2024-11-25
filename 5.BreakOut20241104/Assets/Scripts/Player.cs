using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.0f;
    Vector2 direction;
    
    SpriteRenderer mySr;
    Rigidbody2D myRigid;
    CapsuleCollider2D myCol;

    Ball new_ball = null;
    public Transform ballPos;

    public void SetSize(float value)
    {
        Vector2 tmp = mySr.size;
        tmp.x = value;
        mySr.size = tmp;

        tmp = myCol.size;
        tmp.x = value;
        myCol.size = tmp;
    }

    public float GetSize()
    {
        return mySr.size.x;
    }

    // Start is called before the first frame update
    void Start()
    {
        mySr = GetComponent<SpriteRenderer>();
        myRigid = GetComponent<Rigidbody2D>();
        myCol = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Ball.count == 0 && new_ball == null)
        {
            new_ball = Instantiate<Ball>
                    (GameManager.instance.ballPrefab
                    , ballPos.position
                    , Quaternion.identity
                    , ballPos);
            // GameManager.instance.balls.Add(new_ball);
        }

        if(new_ball != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                new_ball.SetVelocity(
                    (new_ball.transform.position
                    - transform.position).normalized
                    * GameManager.instance.BallSpeedScale);
                new_ball.transform.parent = null;
                new_ball.playing = true;
                new_ball = null;
            }
        }

        // 좌우 판 이동
        direction = Vector2.zero;
        direction.x += Input.GetKey(KeyCode.A) ? -1 : 0;
        direction.x += Input.GetKey(KeyCode.D) ? 1 : 0;
        transform.Translate(direction * speed * Time.deltaTime);

        // 이동 가능 범위 세팅
        float range = 2.5f - GetSize() * 0.5f;
        Vector3 tmp = transform.position;
        tmp.x = Mathf.Clamp(transform.position.x, -range, range);

        transform.position = tmp;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Ball"))
        {
            return;
        }
        GameManager.instance.GetResource().PlayHit1Sound();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 아이템 획득
        if (other.gameObject.CompareTag("BeneficialItem"))
        {
            GameManager.instance.GetResource().PlayPowerUpSound();
        }
        Item hitItem = other.gameObject.GetComponent<Item>();
        if (hitItem) 
            hitItem.ActiveItem(this);
    }
}
