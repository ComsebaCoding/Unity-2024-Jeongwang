using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scripts
public class PlayerControl : MonoBehaviour
{
    enum CharacterAction
    {
        idle = 0,
        meleeAttack,
        shotAttack,
        throwAttack,

        ActionCount
    }

    Camera mainCamera;
    PlayerStatus stat;

    SpriteRenderer playerSr;
    Animator playerAnimator;
    Rigidbody2D playerRigidbody;

    Vector2 MovingDirection;
    Vector2 MouseDirection;
    Transform MouseDirectionObject;
    Transform WeaponPivot;


    Vector3 dashTarget;
    float dashStepTimer = 0.0f; // 대쉬 진행중
    public float dashStepLimitTime = 0.5f;  // 대쉬 총 제한 시간

    public float movingSpeed = 3.0f;    // 일반 이동 속도
    public float dashStepSpeed = 1000.0f; // 대쉬 스텝 중 돌진 속도
    public float jumpPower = 250.0f;      // 점프력

    public bool isJump = false;
    public bool isDashStep = false;

    // private float dash_available_time = 0.1f;
    bool isDashMove = false;

    Vector3 GetMouseWorldPosition()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    public void Jump()
    {
        if (playerRigidbody != null && isJump == false)
        {
            Debug.Log("점프!");
            playerRigidbody.AddForce(Vector2.up * jumpPower * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    public void DashStep(Vector3 targetPosition)
    {
        Debug.Log("대쉬스텝");
        isDashStep = true;
        dashTarget = targetPosition;
        playerRigidbody.AddForce((dashTarget - transform.position).normalized * dashStepSpeed * Time.deltaTime, ForceMode2D.Impulse);
    }

    public void NormalMeleeAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerAnimator.SetBool("isAttack", true);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        MouseDirectionObject = GameObject.Find("MouseDirection").transform;
        WeaponPivot = transform.Find("WeaponPivot");
        if (WeaponPivot == null)
        {
            WeaponPivot = MouseDirectionObject.Find("WeaponPivot");
        }
        playerSr = GetComponent<SpriteRenderer>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        stat = GetComponent<PlayerStatus>();
        MouseDirection = new Vector2(1.0f, 0.0f);
        MouseDirection.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        MouseDirection = GetMouseWorldPosition() - transform.position;
        MouseDirectionObject.rotation
            = Quaternion.AngleAxis(
                Mathf.Atan2(MouseDirection.y, MouseDirection.x) * Mathf.Rad2Deg, 
                Vector3.forward);
        //MouseDirection.Normalize();

        playerSr.flipX = (MouseDirection.x < 0);

        WeaponPivot.rotation
            = Quaternion.Euler(
                new Vector3(
                0.0f,
                (playerSr.flipX) ? -1.0f : 1.0f,
                0.0f)); ;

        
        // 대쉬스텝 상태
        if (isDashStep)
        {
            dashStepTimer += Time.deltaTime;
            //MovingDirection = dashTarget - transform.position;
            //transform.Translate(MovingDirection.normalized * dashStepSpeed * Time.deltaTime);
        }
        else
        {
            if (isDashMove = Input.GetKey(KeyCode.LeftShift)) 
                stat.ConsumeStamina(10.0f * Time.deltaTime);
            MovingDirection = Vector2.zero;
            MovingDirection.x += Input.GetKey(KeyCode.A) ? -1 : 0;
            MovingDirection.x += Input.GetKey(KeyCode.D) ? 1 : 0;
            transform.Translate(MovingDirection.normalized * movingSpeed * ((isDashMove) ? 3.0f : 1.0f) * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.Mouse1) && stat.GetStamina() >= 10)
            {
                stat.ConsumeStamina(25.0f);
                DashStep(GetMouseWorldPosition());
            }
        }

        NormalMeleeAttack();

        if (dashStepTimer >= dashStepLimitTime)
        {
            dashStepTimer = 0.0f;
            isDashStep = false;
        }
        if (transform.position.y < -100.0f)
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

    public void AttackExit()
    {
        playerAnimator.SetBool("isAttack", false);
    }
}