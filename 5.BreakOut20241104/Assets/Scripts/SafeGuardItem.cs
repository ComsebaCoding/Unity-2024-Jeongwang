using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeGuardItem : Item
{
    public GameObject SafeGuardPrefab;
    override public void OnActiveItem(Player player)
    {
        SafeGuard safeGuard = GameObject.FindObjectOfType<SafeGuard>();
        
        if (safeGuard)
            safeGuard.durationTime += safeGuard.increaseDurationTime;
        else
            Instantiate(SafeGuardPrefab);
    }
}