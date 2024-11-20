using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WideItem : Item
{
    public float increaseSize = 1.0f; // ������
    public float MAXSIZE = 5.0f;    // �ִ� ũ��
    public override void OnActiveItem(Player player)
    {
        if (player.GetSize() >= MAXSIZE)
        {
            return;
        }
        player.SetSize(player.GetSize() + increaseSize);
    }
}