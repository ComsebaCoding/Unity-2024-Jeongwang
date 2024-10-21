using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D myrig2d;
    Animator myAnimator;
    public float power = 3.0f;
    AudioSource audioSource;
    public AudioClip upSound;
    public AudioClip starSound;
    public AudioClip hitSound;
    private void Start()
    {
        myrig2d = gameObject.GetComponent<Rigidbody2D>();
        myAnimator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void Up()
    {
        if (myrig2d != null)
        {
            myrig2d.AddForce(Vector2.up * power, ForceMode2D.Impulse);
        }
        audioSource.PlayOneShot(upSound);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)
            || Input.GetKeyDown(KeyCode.UpArrow)
            /*|| (Input.GetKeyDown(KeyCode.Mouse0) 
                && gm.isPlay())*/
            )
        {
            Up();
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        myAnimator.SetBool("isDead", true);
        Invoke("OnDead", 1.0f);
        audioSource.PlayOneShot(hitSound);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        ScrollingRandom scr = other.GetComponent<ScrollingRandom>();
        if (scr != null && other.CompareTag("ScoreItem"))
        {
            scr.Hide();
            GameManager.score += 10;
            audioSource.PlayOneShot(starSound);
        }
        if (other.CompareTag("ScoreZone"))
        {
            GameManager.score += 5;
        }
    }
    
    public GameManager gameManager;
    void OnDead()
    {
        gameManager.GameOver();
    }
}
