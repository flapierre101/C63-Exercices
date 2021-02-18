using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{   
    public float DestroyTimer = 0.2f;
    void Start()
    {
        Destroy(gameObject, DestroyTimer);
    }
}
