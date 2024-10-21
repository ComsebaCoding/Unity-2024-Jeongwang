using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<GameObject> EnemyList;
    public GameObject enemyPrefab;
    public int EnemyCount = 10;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        EnemyList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5.0f)
        {
            timer -= 5.0f;
            if (EnemyList.Count < EnemyCount)
            {
                EnemyList.Add(
                    Instantiate(enemyPrefab,
                        new Vector3(
                            Random.Range(-4.5f, 4.5f),
                            1.0f,
                            Random.Range(-4.5f, 4.5f)
                            ),
                        Quaternion.identity)
                    );
            }
        }
    }
    static public int score = 0;
}
