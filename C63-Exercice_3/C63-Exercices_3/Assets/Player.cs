using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Transform BulletSpawnPoint;
    private health Health;
    public float DestroyTimer = 0;
    private Flash flash;
    private void Start()
    {
        Health = GetComponent<health>();
        flash = GetComponent<Flash>();
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
        DestroyTimer -= Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        var enemy = collider.gameObject.GetComponentInParent<Enemy>();
        if (enemy != null && DestroyTimer <= 0)
        {
            if (Health.hpProp > 0)
            {
                Health.hpProp -= 1;
                DestroyTimer = 1;
                flash.StartFlash();
            }

          
            if(Health.hpProp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
