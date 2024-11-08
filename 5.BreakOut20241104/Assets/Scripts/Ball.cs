using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool playing = false;

    Vector2 direction;
    Rigidbody2D myRigid;

    public float force = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        direction = Random.insideUnitCircle.normalized;
        myRigid.AddForce(direction * force, ForceMode2D.Impulse);
    }

    public void SetVelocity(Vector2 value)
    {
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
                * GameManager.instance.ballSpeed;
        }
    }

    public void OnDestory()
    {
        Destroy(gameObject);
    }
    public void OnDestroy()
    {
        Debug.Log("°øÀÌ ºÎ½¤Áü");
    }
}
