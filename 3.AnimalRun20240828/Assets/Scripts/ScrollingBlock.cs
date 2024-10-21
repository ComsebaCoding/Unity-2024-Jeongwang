using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBlock : MonoBehaviour
{
    BoxCollider2D myBox;
    SpriteRenderer mysr;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        myBox = gameObject.GetComponent<BoxCollider2D>();
        mysr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0.0f, 0.0f));
        if (transform.position.x < -15.0f ){
            transform.Translate(new Vector3(30.0f, 0.0f, 0.0f));

            if (Random.Range(0, 2) == 0)
            {
                myBox.enabled = true;
                mysr.enabled = true;
            }
            else
            {
                myBox.enabled = false;
                mysr.enabled = false;
            }
        }
    }
}
