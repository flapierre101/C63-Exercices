using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public PlatformController PlatformController { get; private set; }
   
    private void Awake()
    {
        PlatformController = GetComponent<PlatformController>();
        PlatformController.OnWall += OnWall;
    }

    private void OnWall(PlatformController platformController)
    {
        PlatformController.FacingController.Flip();
        PlatformController.InputMove = PlatformController.FacingController.Direction;
    }

    private void Update()
    {
        PlatformController.InputMove = PlatformController.FacingController.Direction;
        PlatformController.InputJump = true;

    }
}
