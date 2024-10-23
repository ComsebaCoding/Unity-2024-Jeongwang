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

    public GameObject laserPrefab;  // ����ü ������
    float shootTimer = 0.0f;        // ����ü �߻� Ÿ�̸�
    public float shootCoolTime = 0.2f;     // ����ü �߻� �ֱ� ��Ÿ��

    public GameObject specialLaserPrefab; // Ư����� ������
    float specialShootTimer = 0.0f; // Ư����� Ÿ�̸�
    public float specialShootCoolTime = 2.5f; // Ư����� �߻� �ֱ� ��Ÿ��

    public GameObject chargeLaserPrefab;    // ������� ������
    private float chargingTimer = 0.0f;     // ������� Ÿ�̸�
    public float chargingLimitTime = 1.5f;  // ������� �ð�

    public GameObject homingLaserPrefab;    // ���������� ������
    private float homingTimer = 0.0f;   // ȣ�� �߻� �ֱ� Ÿ�̸�
    public float homingCoolTime = 5.0f; // ȣ�� ��Ÿ��

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
        // * TODO : ��ġ �Է����� ����
        direction = Vector2.zero;
        direction.x += Input.GetKey(KeyCode.LeftArrow) ? -1.0f : 0.0f;
        direction.x += Input.GetKey(KeyCode.RightArrow) ? 1.0f : 0.0f;
        direction.y += Input.GetKey(KeyCode.DownArrow) ? -1.0f : 0.0f;
        direction.y += Input.GetKey(KeyCode.UpArrow) ? 1.0f : 0.0f;
        // ũ�Ⱑ 0�� �ƴ� ������ ũ�⸦ 1�� ����ȭ�ϴ� �Լ�
        direction.Normalize();
        
        // * �Է��� ���� ��쿡�� �̵���
        if (direction.sqrMagnitude > 0.1f)
        {
            // eulerAngle�� ���Ϸ� �����̴�. 0~360�� ������ ���� �����Ѵ�.
            float currentAngle = transform.rotation.eulerAngles.z;
            // SignedAngle �Լ��� ���ڷ� ���� �� ���� ������ ������ return�ϴ� �Լ�
            float targetAngle = Vector2.SignedAngle(Vector2.up, direction);          
            float curVelocity = 0;
            // SmoothDampAngle �Լ��� �������ϰ� �ε巴�� ������ ������ return�ϴ� �Լ�
            // ref�� �� 3��° ���ڿ� ���� ȸ�� �ӵ��� �־ �����ش�.
            currentAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, 
                ref curVelocity, Time.deltaTime, 500);
            // Quaternion.Euler �Լ��� ���ڷ� ���� ������ ���Ϸ� ������ ��ȯ�Ѵ�
            transform.rotation = Quaternion.Euler(0.0f, 0.0f,currentAngle);
        }

        // * �÷��̾� �� �������� �̵�
        myRigid.angularVelocity = 0;
        transform.Translate(Vector2.up * speed * Time.deltaTime,Space.Self);


        // TODO : ��ġ �Է����� ����
        if (Input.GetKey(KeyCode.Space))
        {
            chargingTimer += Time.deltaTime;    
            /*
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootCoolTime)
            {
                shootTimer -= shootCoolTime;
                // �÷��̾� ��ġ�� ����ü ����
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
                // �÷��̾� ��ġ�� ����ü ����
                Instantiate(laserPrefab, 
                    transform.position, transform.rotation);
            }
            chargingTimer = 0.0f;
        }


        specialShootTimer += Time.deltaTime;
        // V Ű�� ���� Ư�� ������ �ߵ�
        if (Input.GetKey(KeyCode.V) && energy > 0)
        {
            if (ShotSound != null)
                GameManager.instance.PlayOneShot(ShotSound);
            if (specialShootTimer >= specialShootCoolTime)
            {
                --energy;
                specialShootTimer -= specialShootCoolTime;
                // �÷��̾� ��ġ�� ����ü ����
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
        // TODO : ü���� 0�� �� ��� ���ӿ��� ó��
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
        // TODO : ���� ���� ó��
        GameManager.instance.GameOver();
    }

    public void StartDeadAnimation()
    {
        if (isDie)
            myAnimator.SetBool("isDead", false);
    }
}
