using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level : MonoBehaviour
{
    public BoxCollider2D LevelCollider;
    public float MonsterTimer = 3, BarrelTimer = 10, SpawnerTimer = 20, PacksTimer = 10;

    private void Start()
    {
        GameManager.Instance.SoundManager.Play(SoundManager.Music.Music); 
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
            GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.monster, RandomPoint(), Quaternion.identity);
        }   
        else if (BarrelTimer <= 0)
        {
            BarrelTimer = 10;
            GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.barrel, RandomPoint(), Quaternion.identity);
        }
        else if (SpawnerTimer <= 0)
        {
            SpawnerTimer = 20;
            GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.spawner, RandomPoint(), Quaternion.identity);
        }
        else if (PacksTimer <= 0)
        {
            PacksTimer = 10;
           
            var PileOuFace = Random.Range(0,2);

            if (PileOuFace == 1)
            {
                GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.pickupHealth, RandomPoint(), Quaternion.identity);
            }
            else
            {
                GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.pickupBomb, RandomPoint(), Quaternion.identity);
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
