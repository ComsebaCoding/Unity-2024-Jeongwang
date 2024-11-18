using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static int count = 0;
    public float speed = 5.0f;

    public bool playing = false;

    Vector2 direction;
    Rigidbody2D myRigid;

    public float force = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        ++count;
        myRigid = GetComponent<Rigidbody2D>();
        direction = Random.insideUnitCircle.normalized;
        //myRigid.AddForce(direction * force, ForceMode2D.Impulse);
    }

    public void SetVelocity(Vector2 value)
    {
        if (myRigid == null)
        {
            myRigid = GetComponent<Rigidbody2D>();
        }
        myRigid.velocity = value;
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            if (Mathf.Abs(myRigid.velocity.x) <= 0.01f)
            {
                myRigid.velocity = new Vector2(
                    Random.Range(1, 3),
                    myRigid.velocity.y);
            }
            if (Mathf.Abs(myRigid.velocity.y) <= 0.01f)
            {
                myRigid.velocity = new Vector2(
                    myRigid.velocity.x, 
                    Random.Range(1, 3));
            }

            myRigid.velocity = myRigid.velocity.normalized
                * speed
                * GameManager.instance.BallSpeedScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            GameManager.instance.Damage();
            Destroy(gameObject);
        }
    }

    public void OnDestroy()
    {
        --count;
    }
}
