using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBallItem : Item
{
    public override void OnActiveItem(Player player)
    {
        // 5/4 ���
        GameManager.instance.BallSpeedScale *= 1.25f;
    }
}