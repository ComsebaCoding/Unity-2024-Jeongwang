using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeMeteor : Meteor
{
    public Meteor meteorPrefab;

    protected override void OnDead()
    {
        base.OnDead();

        for(int i = 0; i < 3; ++i)
        {
            Meteor meteor = Instantiate<Meteor>(
                meteorPrefab, transform.position, Quaternion.identity);
            meteor.direction = Random.insideUnitCircle.normalized;
        }
        GameManager.instance.Score += 2;
    }
}
