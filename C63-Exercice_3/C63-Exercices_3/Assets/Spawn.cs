using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float SpawnTimer = 5;
    public GameObject Enemy, playerObject;
    private health Health;
    public GameObject Explosion;
    public AudioSource audioSourceBullet, audioSourceSpawn, audioSourceExplosion;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = FindObjectOfType<Player>().gameObject;
        Health = GetComponent<health>();

    }
    void Update()
    {
        SpawnTimer -= Time.deltaTime;
        if (SpawnTimer <= 0)
        {
            Instantiate(Enemy, transform.position, transform.rotation);
            audioSourceSpawn.Play();
            SpawnTimer = 5;
        }
        if (Health.hpProp == 0)
        {
            audioSourceExplosion.Play();
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            Health.hpProp -= 1;
            playerObject.GetComponent<Score>().ScoreProp += 25;
            
            Instantiate(Explosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            audioSourceBullet.Play();
            Destroy(collision.gameObject);

        }
    }

}
