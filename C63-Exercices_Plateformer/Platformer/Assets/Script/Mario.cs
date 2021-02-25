using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public PlatformController PlatformController { get; private set; }
    public Animator Animator { get; private set; }
    public Health Health { get; private set; }

    public Vector2 RunAnimationSpeed = new Vector2(0.05f, 0.35f);

    private void Awake()
    {
        PlatformController = GetComponent<PlatformController>();
        PlatformController.OnJump += OnJump;
        PlatformController.OnFall += OnFall;
        PlatformController.OnMoveStart += OnMoveStart;
        PlatformController.OnMoveStop += OnMoveStop;
        PlatformController.OnLand += OnLand;
        Animator = GetComponent<Animator>();
        Health = GetComponent<Health>();
        Health.OnDeath += OnDeath;
    }

    private void OnDeath(Health hp)
    {
        //Destroy(gameObject);
        Animator.Play("Mario_Dead");
        PlatformController.enabled = false;
        PlatformController.Rigidbody2D.simulated = false;
        PlatformController.BoxCollider2D.enabled = false;

        GameManager.Instance.Invoke(nameof(GameManager.RestartLevel), 3.0f);
        Destroy(gameObject);
        
    }

    private void OnLand(PlatformController platformController)
    {
        if (platformController.IsMoving)
        {
            Animator.Play("Mario_Run");
        }
        else
        {
            Animator.Play("Mario_Idle");
        }
    }

    private void OnFall(PlatformController platformController)
    {
        Animator.Play("Mario_Jump");
    }

    private void OnMoveStop(PlatformController platformController)
    {
        if (PlatformController.IsGrounded)
        {
            Animator.Play("Mario_Idle");
        }
        
    }

    private void OnMoveStart(PlatformController platformController)
    {
        if (PlatformController.IsGrounded)
        {
            Animator.Play("Mario_Run");
        }
        
    }

    private void OnJump(PlatformController platformController)
    {
        Animator.Play("Mario_Jump");
    }

    private void Update()
    {
        PlatformController.InputJump = Input.GetButtonDown("Jump");
        PlatformController.InputMove = Input.GetAxisRaw("Horizontal");

        //Run speed

        if (Animator.GetCurrentAnimatorStateInfo(0).IsName("Mario_Run"))
        {
            var speedRatio = Math.Abs(PlatformController.CurrentSpeed / PlatformController.MoveSpeed);
            Animator.speed = RunAnimationSpeed.Lerp(speedRatio);
        }
        else
        {
            Animator.speed = 1.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TEST");

        var health = collision.GetComponentInParent<Health>();
        if (health)
        {
            var marioPosition = PlatformController.BoxCollider2D.bounds.min.y;
            var enemyPosition = collision.bounds.min.y + 0.5 * collision.bounds.extents.y;

            if (marioPosition>enemyPosition)
            {
                // Mario wins
                health.Value -= 1;
                PlatformController.Jump();
                GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.Smoke, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                GameManager.Instance.SoundManager.Play(SoundManager.Sfx.Stomp);
            }
            else
            {
                // Enemy wins

                Health.Value -= 1;
            }
        }

        var spike = collision.GetComponent<Spike>();

        if (spike != null) 
        {
            Health.Value -= 1;
        }
    }
}
