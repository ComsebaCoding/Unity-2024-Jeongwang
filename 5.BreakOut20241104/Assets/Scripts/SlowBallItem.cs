using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBallItem : Item
{
    public override void OnActiveItem(Player player)
    {
        // 4/5 ���
        GameManager.instance.BallSpeedScale *= 0.8f;
    }
}
