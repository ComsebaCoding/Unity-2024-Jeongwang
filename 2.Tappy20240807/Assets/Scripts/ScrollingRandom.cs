using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingRandom : MonoBehaviour
{
    private Collider2D col2d;
    SpriteRenderer sr;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        col2d = gameObject.GetComponent<Collider2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0.0f, 0.0f));
        if (transform.position.x < -15.0f)
        {
            transform.Translate(new Vector3(30.0f, 0.0f, 0.0f));
            if (Random.Range(0, 2) == 0)
            {
                col2d.enabled = true;
                sr.enabled = true;
            }
            else
            {
                Hide();
            }
        }
    }

    public void Hide()
    {
        col2d.enabled = false;
        sr.enabled = false;
    }
}