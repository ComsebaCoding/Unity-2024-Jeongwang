﻿using UnityEditor;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }
    public GameObject Instantiate(string path, Transform parent = null)
    {
        // GameObject prefab = Resources.Load<GameObject>("Prefab/Tank");
        GameObject prefab = Resources.Load<GameObject>($"Prefab/{path}");
        if (prefab == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }
        return Object.Instantiate(prefab, parent);
    }
    public void Destroy(GameObject gobj)
    {
        if (gobj == null) return;
        Object.Destroy(gobj);
    }
}