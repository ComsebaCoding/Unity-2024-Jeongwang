using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrowItem : Item
{
    public float decreaseSize = 0.1f; // ���ҷ�
    public float MINSIZE = 0.5f;    // �ּ� ũ��

    public override void OnActiveItem(Player player)
    {
        if (player.GetSize() <= MINSIZE)
        {
            return;
        }
        player.SetSize(player.GetSize() - decreaseSize);
    }
}