using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public GameObject BombObj;
    public Transform BulletSpawnPoint;
    private health Health { get;  set; }
    public float InvincibleTimer = 0;
    private Flash flash;
    private Bomb Bomb;
    private Score Score;
    public AudioSource audioSourcePistol, audioSourceShotgun, audioSourceHurt, audioSourceExplosion;


    private void Start()
    {
        Health = GetComponent<health>();
        flash = GetComponent<Flash>();
        Bomb = GetComponent<Bomb>();
        Score = GetComponent<Score>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //var rotation = transform.rotation * Quaternion.Euler(0.0f,0.0f,-30.0f);
            Instantiate(bullet, BulletSpawnPoint.position, transform.rotation);
            audioSourcePistol.Play();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            var rotation1 = transform.rotation * Quaternion.Euler(0.0f, 0.0f, -30.0f);
            var rotation2 = transform.rotation * Quaternion.Euler(0.0f, 0.0f, 30.0f);
            Instantiate(bullet, BulletSpawnPoint.position, transform.rotation);
            Instantiate(bullet, BulletSpawnPoint.position, rotation1);
            Instantiate(bullet, BulletSpawnPoint.position, rotation2);
            audioSourceShotgun.Play();
        }
        else if (Input.GetMouseButtonDown(2))
        {
            if (Bomb._startBomb > 0)
            {
                Instantiate(BombObj, BulletSpawnPoint.position, transform.rotation);
                Bomb._startBomb -= 1;
            }
        }
        InvincibleTimer -= Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        var enemy = collider.gameObject.GetComponentInParent<Enemy>();
        if (enemy != null && InvincibleTimer <= 0)
        {
            if (Health.hpProp > 0)
            {
                Health.hpProp -= 1;
                audioSourceHurt.Play();
                InvincibleTimer = 2;
                flash.StartFlash();
            }

          
            if(Health.hpProp <= 0)
            {
                audioSourceExplosion.Play();
                Destroy(gameObject);
            }
        }
    }
}
