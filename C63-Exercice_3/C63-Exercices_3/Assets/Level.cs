using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public BoxCollider2D LevelCollider;
    public GameObject MonsterObject;
    public float MonsterTimer = 3;
    // Update is called once per frame
    void Update()
    {
        //spawner
        MonsterTimer -= Time.deltaTime;
        if (MonsterTimer<=0)
        {
            MonsterTimer = 3;
            var x = Random.Range(
                LevelCollider.bounds.min.x,
                LevelCollider.bounds.max.x);
            var y = Random.Range(
               LevelCollider.bounds.min.y,
               LevelCollider.bounds.max.y);
            Instantiate(MonsterObject, new Vector3(x, y, 0), Quaternion.identity);
        }
    }
}
