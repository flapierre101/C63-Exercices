using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 1;
    public GameObject playerObject {  get; private set; }
    public health Health;
    public GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = FindObjectOfType<Player>().gameObject;
        Health = GetComponent<health>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position =  Vector3.MoveTowards(transform.position, playerObject.transform.position, Speed * Time.deltaTime);
        transform.right = playerObject.transform.position - transform.position;
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
