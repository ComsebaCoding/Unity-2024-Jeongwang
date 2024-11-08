using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hp = 3;
    public List<Color> colors;

    SpriteRenderer mySr;

    // Start is called before the first frame update
    void Start()
    {
        mySr = GetComponent<SpriteRenderer>();
        if (mySr == null)
        {
            Debug.Log("Sprite Renderer Load Failed.");
        }
        mySr.color = colors[Mathf.Clamp(hp, 0, colors.Count - 1)];
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            --hp;
            mySr.color = colors[Mathf.Clamp(hp, 0, colors.Count - 1)];
            if (hp <= 0)
            {
                OnDead();
            }
        }
    }

    void OnDead()
    {
        // 나중에 여기서 아이템 생성

        Destroy(gameObject);
    }
}
