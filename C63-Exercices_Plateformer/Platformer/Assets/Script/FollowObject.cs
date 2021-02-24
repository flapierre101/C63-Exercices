using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
  
    public Transform TargetTransform;

    void LateUpdate()
    {
        transform.position = TargetTransform.position.WithZ(transform.position.z);
    }
}
