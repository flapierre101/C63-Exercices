using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMouvement : MonoBehaviour
{
    public float Speed;
   
    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        var patate = new Vector3(horizontal, vertical, 0);

        if (patate.magnitude > 1)
            patate = patate.normalized;

        transform.position += patate * Speed * Time.deltaTime;
    }
}
