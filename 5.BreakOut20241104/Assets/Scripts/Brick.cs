using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hp = 3;
    public List<Color> colors;
    public List<Item> dropItems;

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
            GameManager.instance.GetResource().PlayHit2Sound();
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
        // 숫자 1~10 중 하나를 뽑아 드랍 확률 조절
        if (Random.Range(1,11) <= 10) 
        {
            Item pickItem = dropItems[Random.Range(0, dropItems.Count)];
            Instantiate(pickItem, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}