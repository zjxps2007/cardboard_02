using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    private float surviveTime;
    private float time;

    // Update is called once per frame
    void Update()
    {
        surviveTime += Time.deltaTime;
        time += Time.deltaTime;

        if (surviveTime <= 10)
        {
            if (time >= 2)
            {
                EnemyInstantiate();
                time = 0;
            }
        }
        else if (surviveTime <= 20)
        {
            if (time >= 1)
            {
                EnemyInstantiate();
                time = 0;
            }
        }
        else
        {
            if (time >= 0.5f)
            {
                EnemyInstantiate();
                time = 0;
            }
        }
    }

    void EnemyInstantiate()
    {
        Vector3 pos = new Vector3(Random.Range(-15, 15), Random.Range(10, -10), 40);
        Instantiate(enemy, pos, transform.rotation);
    }
}
