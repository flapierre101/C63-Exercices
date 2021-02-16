using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 1;
    public GameObject playerObject {  get; private set; }
    public Health Health;
    public GameObject Explosion;
    public AudioSource audioSourceBullet, audioSourceExplosion;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = FindObjectOfType<Player>().gameObject;
        Health = GetComponent<Health>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position =  Vector3.MoveTowards(transform.position, playerObject.transform.position, Speed * Time.deltaTime);
        transform.right = playerObject.transform.position - transform.position;
        if (Health.Value == 0)
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
          
            Health.Value -= 1;
            playerObject.GetComponent<Score>().ScoreProp += 25;
            
            Instantiate(Explosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            audioSourceBullet.Play();
            Destroy(collision.gameObject);
            
        }
    }
}
