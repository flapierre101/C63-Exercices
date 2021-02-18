using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform TargetTransform;
    void Awake()
    {
        TargetTransform = GameManager.Instance.Player.transform;
    }
    void LateUpdate()
    {
        transform.position = TargetTransform.position.WithZ(transform.position.z);
    }
}
