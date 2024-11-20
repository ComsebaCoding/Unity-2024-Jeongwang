using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WideItem : Item
{
    public float increaseSize = 1.0f; // 증가량
    public float MAXSIZE = 5.0f;    // 최대 크기
    public override void OnActiveItem(Player player)
    {
        if (player.GetSize() >= MAXSIZE)
        {
            return;
        }
        player.SetSize(player.GetSize() + increaseSize);
    }
}