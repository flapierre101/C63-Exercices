using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{   
    public float DestroyTimer = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
