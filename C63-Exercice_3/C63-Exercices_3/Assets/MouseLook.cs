using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    void Update()
    {
        var mousePosition = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var lookAtAngle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(lookAtAngle, Vector3.forward);

    }
}
