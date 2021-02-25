using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public PlatformController PlatformController { get; private set; }
    public Animator Animator { get; private set; }

    private Mario Mario;
    private void Awake()
    {
        PlatformController.OnMoveStart += OnMoveStart;
        PlatformController.OnMoveStop += OnMoveStop;
        Mario = GameManager.Instance.Mario;
        Animator = GetComponent<Animator>();
    }

    private void OnMoveStop(PlatformController platformController)
    {
        Animator.Play("Shell_Idle");
    }

    private void OnMoveStart(PlatformController platformController)
    {
        Animator.Play("Shell_Move");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponentInParent<Health>();
        if (health)
        {
            if (collision.gameObject == Mario)
            {
                Mario.Health.Value -= 1;
            }
            else
            {
                health.Value -= health.Value;
            }
        }

    }
}
