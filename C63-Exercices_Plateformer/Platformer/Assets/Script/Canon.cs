using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public float fireTimer = 4;
    public PlatformController PlatformController { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!GameManager.Instance.IsInsideCamera(gameObject.GetComponent<SpriteRenderer>()))
        {
            fireTimer -= Time.deltaTime;
            if (fireTimer <= 0.0)
            {
                
            }
        }
    }
}
