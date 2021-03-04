using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public enum State
    {
        Small,
        Big,
        Fire,
    }
    public enum Animation
    {
        Idle,
        Jump,
        Run,
        Dead,
    }

    private State _currentState;

    public State CurrentState
    {
        get { return _currentState; }
        set 
        { 
            _currentState = value;
            UpdateAnimations();
        }
    }
    private Animation _currentAnimation;

    public Animation CurrentAnimation
    {
        get { return _currentAnimation; }
        set
        {
            _currentAnimation = value;
            UpdateAnimations();
        }
    }


    public string AnimationName
    {
        get
        {
            var prefix = CurrentState.ToString();
            var suffix = CurrentAnimation.ToString();
            return "Mario_" + prefix + "_" + suffix;
        }
    }
    private void UpdateAnimations()
    {
        var animationName = AnimationName;
        Animator.Play(animationName);
    }

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
        CurrentState = State.Small;
    }

    private void OnDeath(Health hp)
    {
        GameManager.Instance.SoundManager.Play(SoundManager.Sfx.Dead);
        PlatformController.enabled = false;
        PlatformController.Rigidbody2D.simulated = false;
        PlatformController.BoxCollider2D.enabled = false;

        GameManager.Instance.Invoke(nameof(GameManager.RestartLevel), 3.0f);
        CurrentAnimation = Animation.Dead;
        //Destroy(gameObject);

    }

    private void OnLand(PlatformController platformController)
    {
        if (platformController.IsMoving)
        {
            CurrentAnimation = Animation.Run;
        }
        else
        {
            CurrentAnimation = Animation.Idle;
        }
    }

    private void OnFall(PlatformController platformController)
    {
        if (!PlatformController.IsGrounded)
        {
            CurrentAnimation = Animation.Jump;
        }
    }

    private void OnMoveStop(PlatformController platformController)
    {
        if (PlatformController.IsGrounded)
        {
            CurrentAnimation = Animation.Idle;
        }

    }

    private void OnMoveStart(PlatformController platformController)
    {
        if (PlatformController.IsGrounded)
        {
            CurrentAnimation = Animation.Run;
        }

    }

    private void OnJump(PlatformController platformController)
    {
        CurrentAnimation = Animation.Jump;
    }

    private void Update()
    {
        PlatformController.InputJump |= Input.GetButtonDown("Jump");
        PlatformController.InputMove = Input.GetAxisRaw("Horizontal");

        //Run speed

        if (CurrentAnimation == Animation.Run)
        {
            var speedRatio = Math.Abs(PlatformController.CurrentSpeed / PlatformController.MoveSpeed);
            Animator.speed = RunAnimationSpeed.Lerp(speedRatio);
        }
        else
        {
            Animator.speed = 1.0f;
        }

        //Testing State inputs

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentState = State.Small;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentState = State.Big;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentState = State.Fire;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTrigger(collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTrigger(collision);
    }

    private void OnTrigger(Collider2D collision)
    {
        Debug.Log("TEST");

        var health = collision.GetComponentInParent<Health>();
        if (health && health.CanBeDamaged)
        {
            var marioPosition = PlatformController.BoxCollider2D.bounds.min.y;
            var enemyPosition = collision.bounds.min.y + 0.5 * collision.bounds.extents.y;

            if (marioPosition > enemyPosition)
            {
                // Mario wins
                health.Value -= 1;
                PlatformController.Jump();
                GameManager.Instance.SoundManager.Play(SoundManager.Sfx.Jump);
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
