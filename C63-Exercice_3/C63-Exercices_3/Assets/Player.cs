using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Transform BulletSpawnPoint;
    private health Health;
    public float DestroyTimer = 1;
    private void Start()
    {
        Health = GetComponent<health>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //var rotation = transform.rotation * Quaternion.Euler(0.0f,0.0f,-30.0f);
            Instantiate(bullet, BulletSpawnPoint.position, transform.rotation);

        }
        else if (Input.GetMouseButtonDown(1))
        {
            var rotation1 = transform.rotation * Quaternion.Euler(0.0f, 0.0f, -30.0f);
            var rotation2 = transform.rotation * Quaternion.Euler(0.0f, 0.0f, 30.0f);
            Instantiate(bullet, BulletSpawnPoint.position, transform.rotation);
            Instantiate(bullet, BulletSpawnPoint.position, rotation1);
            Instantiate(bullet, BulletSpawnPoint.position, rotation2);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            DestroyTimer -= Time.deltaTime;
            if (DestroyTimer <= 0)
            {
                Health.hpProp -= 1;
                DestroyTimer = 1;
            }

          
            if(Health.hpProp == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
