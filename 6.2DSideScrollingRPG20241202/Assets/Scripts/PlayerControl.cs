using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scripts
public class PlayerControl : MonoBehaviour
{
    enum CharacterAction
    {
        idle = 0,

        ActionCount
    }

    Camera mainCamera;
    PlayerStatus stat;

    Rigidbody2D playerRigidbody;

    Vector2 MovingDirection;
    Vector2 AttackDirection;
    RectTransform AttackDirectionRT;
    Vector3 dashTarget;
    float dashStepTimer = 0.0f; // 대쉬 진행중
    public float dashStepLimitTime = 0.5f;  // 대쉬 총 제한 시간

    public float movingSpeed = 3.0f;    // 일반 이동 속도
    public float dashStepSpeed = 10.0f; // 대쉬 스텝 중 돌진 속도
    public float jumpPower = 250.0f;      // 점프력

    public bool isJump = false;
    public bool isDashStep = false;

    Vector3 GetMouseWorldPosition()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
    public void Jump()
    {
        if (playerRigidbody != null && isJump == false)
        {
            Debug.Log("점프!");
            playerRigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Force);
        }
    }

    public void DashStep(Vector3 targetPosition)
    {
        Debug.Log("대쉬스텝");
        isDashStep = true;
        dashTarget = targetPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        AttackDirectionRT = GameObject.Find("AttackDirectionCanvas").GetComponent<RectTransform>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        stat = GetComponent<PlayerStatus>();
        AttackDirection = new Vector2(1.0f, 0.0f);
        AttackDirection.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        AttackDirection = GetMouseWorldPosition() - transform.position;
        AttackDirection.Normalize();
        AttackDirectionRT.transform.rotation
            = Quaternion.AngleAxis(
                Mathf.Atan2(AttackDirection.y, AttackDirection.x) * Mathf.Rad2Deg, 
                Vector3.forward);

        



        if (isDashStep)
        {
            dashStepTimer += Time.deltaTime;
            MovingDirection = dashTarget - transform.position;
            transform.Translate(MovingDirection * dashStepSpeed * Time.deltaTime);
        }
        else
        {
            MovingDirection = Vector2.zero;
            MovingDirection.x += Input.GetKey(KeyCode.A) ? -1 : 0;
            MovingDirection.x += Input.GetKey(KeyCode.D) ? 1 : 0;
            transform.Translate(MovingDirection * movingSpeed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.Mouse1) && stat.GetStamina() >= 10)
            {
                stat.ConsumStamina(25.0f);
                DashStep(GetMouseWorldPosition());
            }
        }
        if (dashStepTimer >= dashStepLimitTime)
        {
            dashStepTimer = 0.0f;
            isDashStep = false;
        }
        if (transform.position.y < - 100.0f)
        {
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovableZone"))
            isJump = false;

        if (collision.gameObject.CompareTag("Monster"))
        {
            MonsterStatus ms = collision.gameObject.GetComponent<MonsterStatus>();
            stat.Damaged(ms.MonsterCollideAttack());
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovableZone"))
            isJump = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovableZone"))
            isJump = true;
    }
}
