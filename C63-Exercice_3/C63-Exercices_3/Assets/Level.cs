using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level : MonoBehaviour
{
    public BoxCollider2D LevelCollider;
    public GameObject MonsterObject, BarrelObject, SpawnerObject, PackHealth, PackBomb;
    public float MonsterTimer = 3, BarrelTimer = 10, SpawnerTimer = 20, PacksTimer = 10;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource.volume = 0.10F;
        audioSource.Play();
    }
    void Update()
    {
        //spawner
        MonsterTimer -= Time.deltaTime;
        BarrelTimer -= Time.deltaTime;
        SpawnerTimer -= Time.deltaTime;
        PacksTimer -= Time.deltaTime;

        if (MonsterTimer<=0)
        {
            MonsterTimer = 3;
            Instantiate(MonsterObject, RandomPoint(), Quaternion.identity);
        }   
        else if (BarrelTimer <= 0)
        {
            BarrelTimer = 10;
            Instantiate(BarrelObject, RandomPoint(), Quaternion.identity);
        }
        else if (SpawnerTimer <= 0)
        {
            SpawnerTimer = 20;
            Instantiate(SpawnerObject, RandomPoint(), Quaternion.identity);
        }
        else if (PacksTimer <= 0)
        {
            PacksTimer = 10;
           
            var PileOuFace = Random.Range(0,2);

            if (PileOuFace == 1)
            {
                Instantiate(PackHealth, RandomPoint(), Quaternion.identity);
            }
            else
            {
                Instantiate(PackBomb, RandomPoint(), Quaternion.identity);
            }
            
        }
    }

    private Vector3 RandomPoint()
    {
        Vector3 tempoVecteur3;
        var x = Random.Range(
                LevelCollider.bounds.min.x,
                LevelCollider.bounds.max.x);
        var y = Random.Range(
           LevelCollider.bounds.min.y,
           LevelCollider.bounds.max.y);

        tempoVecteur3 = new Vector3(x, y, 0);
        
        return tempoVecteur3;
    } 
}
