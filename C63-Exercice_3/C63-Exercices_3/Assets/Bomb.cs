using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int _startBomb = 1;
    public GameObject ExplosionBarrel;
    public GameObject Bullet;
    public float DestroyTimer = 1;
    private Flash flash;
    
    void Start()
    {
        flash = GetComponent<Flash>();
        flash.StartFlash();
    }

    private void Update()
    {
        DestroyTimer -= Time.deltaTime;
        if (DestroyTimer <= 0)
        {
            float tempo = 45.0f;
            for (int i = 1; i <= 8; i++)
            {
                var rotation1 = transform.rotation * Quaternion.Euler(0.0f, 0.0f, tempo * i);
                Instantiate(Bullet, gameObject.transform.position, rotation1);
            }

            Destroy(gameObject);
            Instantiate(ExplosionBarrel, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
    public int BombProp
    {
        get { return _startBomb; }
        set { _startBomb = value; }
    }
}
