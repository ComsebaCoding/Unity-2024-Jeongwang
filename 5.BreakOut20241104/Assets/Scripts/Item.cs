using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Item : MonoBehaviour
{
    void Update()
    {
        transform.position -= new Vector3(0.0f, Time.deltaTime * 1.0f);
    }

    public void ActiveItem(Player player)
    {
        OnActiveItem(player);
        Destroy(gameObject);
    }

    abstract public void OnActiveItem(Player player);
}
