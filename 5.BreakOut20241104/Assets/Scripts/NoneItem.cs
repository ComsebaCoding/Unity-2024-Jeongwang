using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoneItem : Item
{
    public override void OnActiveItem(Player player)
    {
        Debug.Log("None Item Get : " + 
            transform.position.x + "," + transform.position.y);
    }
}