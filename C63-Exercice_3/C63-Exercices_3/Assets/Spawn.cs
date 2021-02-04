using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float SpawnTimer = 2;
    public GameObject Enemy;
    // Start is called before the first frame update

    void Update()
    {
        SpawnTimer -= Time.deltaTime;
        if (SpawnTimer <= 0)
        {
            Instantiate(Enemy, transform.position, transform.rotation);
            SpawnTimer = 2;
        }
        
    }
}
