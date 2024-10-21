using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D myrigid2d;
    Animator myAnimator;
    public float JumpPower = 6.5f;
    AudioSource myAudioSource;
    public AudioClip jumpSound;
    public AudioClip groundSound;
    public AudioClip hitSound;

    enum state
    {
        dog,
        cat
    }
    private state playerType = state.dog;

    // Start is called before the first frame update
    void Start()
    {
        myrigid2d = gameObject.GetComponent<Rigidbody2D>();
        myAnimator = gameObject.GetComponent<Animator>();
        myAudioSource = gameObject.GetComponent<AudioSource>();
    }

    public void Jump()
    {
        if (myAnimator.GetBool("isJump")) 
            return;

        myrigid2d.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        myAnimator.SetBool("isJump", true);
        myAudioSource.PlayOneShot(jumpSound);
    }

    // Update is called once per frame
    void Update()
    {
        float randvalue = Random.Range(0.0f, 2.0f);
        if (randvalue > 1.999f) Debug.Log(randvalue + "ªÃ¿Ω");

        if (Input.GetKeyDown(KeyCode.F1))
        {
            playerType = state.dog;
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            playerType = state.cat;
        }
        switch (playerType)
        {
            case state.dog:
                myAnimator.SetInteger("playerType", 1);
                break;
            case state.cat:
                myAnimator.SetInteger("playerType", 2);
                break;
        }

        if (Input.GetKeyDown(KeyCode.Space)
            || Input.GetKeyDown(KeyCode.Mouse0)
            || Input.GetKeyDown(KeyCode.Mouse1)
            )
            Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        myAnimator.SetBool("isJump", false);
        myAudioSource.PlayOneShot(groundSound);
    }

    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.GameOver();
        myAudioSource.PlayOneShot(hitSound);
    }
}
