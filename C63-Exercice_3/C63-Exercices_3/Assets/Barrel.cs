using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public health Health;
    public GameObject ExplosionBarrel;
    public GameObject Bullet;
    public float DestroyTimer = 2;
    private Flash flash;
    public AudioSource audioSourceBullet, audioSourceExplosion;
    // Start is called before the first frame update
    void Start()
    {
        Health = GetComponent<health>();
        flash = GetComponent<Flash>();
    }

    // Update is called once per frame
    void Update()
    {

        if (flash.enabled)
        {
            DestroyTimer -= Time.deltaTime;
            if (DestroyTimer <= 0)
            {
                float tempo = 45.0f;
                for (int i = 1; i <= 8; i++)
                {
                    var rotation1 = transform.rotation * Quaternion.Euler(0.0f, 0.0f, tempo*i);
                    Instantiate(Bullet, gameObject.transform.position, rotation1);
                }
                audioSourceExplosion.Play();
                Destroy(gameObject);
                Instantiate(ExplosionBarrel, gameObject.transform.position, gameObject.transform.rotation);
            }

        }

        if (Health.hpProp == 0)
            if (!flash.enabled)
                flash.StartFlash();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            Health.hpProp -= 1;
            audioSourceBullet.Play();
            Destroy(collision.gameObject);

        }
    }
}
