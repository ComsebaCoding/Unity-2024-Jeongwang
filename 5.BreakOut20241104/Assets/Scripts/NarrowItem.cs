using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrowItem : Item
{
    public float decreaseSize = 0.1f; // 감소량
    public float MINSIZE = 0.5f;    // 최소 크기

    public override void OnActiveItem(Player player)
    {
        if (player.GetSize() <= MINSIZE)
        {
            return;
        }
        player.SetSize(player.GetSize() - decreaseSize);
    }
}