using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float SpawnTimer = 5;
    public GameObject Enemy;
    private health Health;
    public GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
        
        Health = GetComponent<health>();

    }
    void Update()
    {
        SpawnTimer -= Time.deltaTime;
        if (SpawnTimer <= 0)
        {
            Instantiate(Enemy, transform.position, transform.rotation);
            SpawnTimer = 5;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            Health.hpProp -= 1;

            if (Health.hpProp == 0)
            {
                Destroy(gameObject);
            }
            Instantiate(Explosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);

            Destroy(collision.gameObject);

        }
    }

}
