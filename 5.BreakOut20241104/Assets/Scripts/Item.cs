using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Item : MonoBehaviour
{
    void Update()
    {
        // 아이템이 아래로 천천히 떨어짐
        transform.position -= new Vector3(0.0f, Time.deltaTime * 1.0f);
    }

    // 플레이어가 아이템을 먹었을 때
    public void ActiveItem(Player player)
    {
        OnActiveItem(player);   // 아이템 효과 발동
        Destroy(gameObject);    // 먹은 아이템 삭제
    }
    
    abstract public void OnActiveItem(Player player); // 효과는 아이템별로 구현
}
