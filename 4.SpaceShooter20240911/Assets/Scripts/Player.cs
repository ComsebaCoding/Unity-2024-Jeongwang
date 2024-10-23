using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp = 5;
    public int energy = 5;
    public SpriteRenderer damageRenderer;
    public List<Sprite> damageSpriteList = new List<Sprite>();
    Rigidbody2D myRigid;
    Animator myAnimator;

    public AudioClip ShotSound;
    public AudioClip HitSound;
    public AudioClip DestroySound;

    Vector2 direction;
    public float speed = 3.0f;
    private bool isDie = false;

    public GameObject laserPrefab;  // 투사체 프리팹
    float shootTimer = 0.0f;        // 투사체 발사 타이머
    public float shootCoolTime = 0.2f;     // 투사체 발사 주기 쿨타임

    public GameObject specialLaserPrefab; // 특수사격 프리팹
    float specialShootTimer = 0.0f; // 특수사격 타이머
    public float specialShootCoolTime = 2.5f; // 특수사격 발사 주기 쿨타임

    public GameObject chargeLaserPrefab;    // 차지사격 프리팹
    private float chargingTimer = 0.0f;     // 기모으기 타이머
    public float chargingLimitTime = 1.5f;  // 기모으는 시간

    public GameObject homingLaserPrefab;    // 유도레이저 프리팹
    private float homingTimer = 0.0f;   // 호밍 발사 주기 타이머
    public float homingCoolTime = 5.0f; // 호밍 쿨타임

    // Start is called before the first frame update
    void Start()
    {
        myRigid = gameObject.GetComponent<Rigidbody2D>();
        myAnimator = gameObject.GetComponent<Animator>();
        damageRenderer.sprite = damageSpriteList[hp];
    }

    // Update is called once per frame
    void Update()
    {
        // * TODO : 터치 입력으로 변경
        direction = Vector2.zero;
        direction.x += Input.GetKey(KeyCode.LeftArrow) ? -1.0f : 0.0f;
        direction.x += Input.GetKey(KeyCode.RightArrow) ? 1.0f : 0.0f;
        direction.y += Input.GetKey(KeyCode.DownArrow) ? -1.0f : 0.0f;
        direction.y += Input.GetKey(KeyCode.UpArrow) ? 1.0f : 0.0f;
        // 크기가 0이 아닌 벡터의 크기를 1로 정규화하는 함수
        direction.Normalize();
        
        // * 입력이 있을 경우에만 이동함
        if (direction.sqrMagnitude > 0.1f)
        {
            // eulerAngle은 오일러 각도이다. 0~360도 사이의 값만 존재한다.
            float currentAngle = transform.rotation.eulerAngles.z;
            // SignedAngle 함수는 인자로 들어온 두 벡터 사이의 각도를 return하는 함수
            float targetAngle = Vector2.SignedAngle(Vector2.up, direction);          
            float curVelocity = 0;
            // SmoothDampAngle 함수는 스무스하고 부드럽게 각도를 변경해 return하는 함수
            // ref로 들어간 3번째 인자에 현재 회전 속도를 넣어서 돌려준다.
            currentAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, 
                ref curVelocity, Time.deltaTime, 500);
            // Quaternion.Euler 함수는 인자로 들어온 각도를 오일러 각도로 변환한다
            transform.rotation = Quaternion.Euler(0.0f, 0.0f,currentAngle);
        }

        // * 플레이어 위 방향으로 이동
        myRigid.angularVelocity = 0;
        transform.Translate(Vector2.up * speed * Time.deltaTime,Space.Self);


        // TODO : 터치 입력으로 변경
        if (Input.GetKey(KeyCode.Space))
        {
            chargingTimer += Time.deltaTime;    
            /*
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootCoolTime)
            {
                shootTimer -= shootCoolTime;
                // 플레이어 위치에 투사체 생성
                Instantiate(laserPrefab, transform.position, transform.rotation);
            } */        
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (ShotSound != null)
                GameManager.instance.PlayOneShot(ShotSound);
            if (chargingTimer >= chargingLimitTime)
            {
                Instantiate(chargeLaserPrefab, 
                    transform.position, transform.rotation);
            }
            else
            {
                // 플레이어 위치에 투사체 생성
                Instantiate(laserPrefab, 
                    transform.position, transform.rotation);
            }
            chargingTimer = 0.0f;
        }


        specialShootTimer += Time.deltaTime;
        // V 키를 눌러 특수 레이저 발동
        if (Input.GetKey(KeyCode.V) && energy > 0)
        {
            if (ShotSound != null)
                GameManager.instance.PlayOneShot(ShotSound);
            if (specialShootTimer >= specialShootCoolTime)
            {
                --energy;
                specialShootTimer -= specialShootCoolTime;
                // 플레이어 위치에 투사체 생성
                Instantiate(specialLaserPrefab, transform.position, transform.rotation);
            }
        }

        homingTimer += Time.deltaTime;
        if (homingTimer >= homingCoolTime)
        {
            if (ShotSound != null)
                GameManager.instance.PlayOneShot(ShotSound);
            homingTimer -= homingCoolTime;
            Instantiate(homingLaserPrefab, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hp < 5 && other.gameObject.CompareTag("Item"))
        {
            damageRenderer.sprite = damageSpriteList[++hp];
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // --hp;
            GameManager.instance.PlayOneShot(HitSound);
            damageRenderer.sprite = damageSpriteList[--hp];
        }
        // TODO : 체력이 0이 될 경우 게임오버 처리
        if (hp <= 0 && !isDie)
        {
            if (DestroySound != null)
                GameManager.instance.PlayOneShot(DestroySound);
            myAnimator.SetBool("isDead", true);
            isDie = true;
        }    
    }

    public void OnDead()
    {
        // TODO : 게임 오버 처리
        GameManager.instance.GameOver();
    }

    public void StartDeadAnimation()
    {
        if (isDie)
            myAnimator.SetBool("isDead", false);
    }
}
