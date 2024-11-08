using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeItem : Item
{
    override public void OnActiveItem(Player player)
    {
        GameManager.instance.Heal();
    }
}