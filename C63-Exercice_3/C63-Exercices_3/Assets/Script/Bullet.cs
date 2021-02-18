using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float Speed = 10;
    private float DestroyTimer = 3;
    void Update()
    {
        transform.position += transform.right * Speed * Time.deltaTime;

        DestroyTimer -= Time.deltaTime;
        if (DestroyTimer <= 0)
            Destroy(gameObject);
    }
}
