using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    private Time t;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Vector3 pos = new Vector3(Random.Range(-15, 15), Random.Range(10, -10), 40);
            Instantiate(enemy, pos, transform.rotation);
        }
    }
}
