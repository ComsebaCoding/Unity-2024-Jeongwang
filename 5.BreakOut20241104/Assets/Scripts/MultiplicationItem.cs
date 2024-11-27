using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplicationItem : Item
{
    public override void OnActiveItem(Player player)
    {
        foreach (Ball ball in FindObjectsOfType<Ball>())
        {
            ball.Clone();
        }
    }
}