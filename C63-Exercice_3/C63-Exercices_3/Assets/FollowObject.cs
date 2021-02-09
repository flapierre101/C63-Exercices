using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Transform TargetTransform;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = TargetTransform.position.WithZ(transform.position.z);
    }
}
