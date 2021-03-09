using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public PlatformController PlatformController { get; private set; }
    public Animator Animator { get; private set; }

    private Mario Mario;
    private bool isMoving = false;

    private void Awake()
    {
        PlatformController = GetComponent<PlatformController>();
        Animator = GetComponent<Animator>();
        PlatformController.OnMoveStart += OnMoveStart;
        PlatformController.OnMoveStop += OnMoveStop;
        PlatformController.OnWall += OnWall;
        Mario = GameManager.Instance.Mario;
    }

    private void OnMoveStop(PlatformController platformController)
    {
        Animator.Play("Shell_Idle");
    }

    private void OnMoveStart(PlatformController platformController)
    {
        PlatformController.InputMove = PlatformController.FacingController.Direction;
        Animator.Play("Shell_Move");
    }
    private void OnWall(PlatformController platformController)
    {
        PlatformController.FacingController.Flip();
        PlatformController.InputMove = PlatformController.FacingController.Direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponentInParent<Health>();
        if (health)
        {
            
            var shellPosition = PlatformController.BoxCollider2D.bounds.min.y + 0.5 * PlatformController.BoxCollider2D.bounds.extents.y;
            var marioPosition = collision.bounds.min.y;
            
            if (marioPosition < shellPosition && PlatformController.IsMoving)
            {
                if (!collision.GetComponent<Mario>())
                {
                    health.Value -= health.Value;
                }
                else
                {
                    if (health.InvincibilityTimer <= 0.0f)
                    {
                        health.Value -= 1;
                    }
                }
                
            }
            else if (collision.GetComponent<Mario>())
            {
                
                if (PlatformController.IsMoving)
                {
                    Mario.PlatformController.Jump();
                    isMoving = false;
                    PlatformController.InputMove = 0;
                }
                else
                {
                    isMoving = true;
                    if (Mario.GetComponent<Transform>().position.x < gameObject.GetComponent<Transform>().position.x)
                    {
                        PlatformController.FacingController.Facing = Facing.Right;
                    }
                    else
                    {
                        PlatformController.FacingController.Facing = Facing.Left;
                    }
                    GameManager.Instance.SoundManager.Play(SoundManager.Sfx.Kick);
                }
            }
        }


    }
    private void Update()
    {
        if (isMoving)
            PlatformController.InputMove = PlatformController.FacingController.Direction;
    }
}
