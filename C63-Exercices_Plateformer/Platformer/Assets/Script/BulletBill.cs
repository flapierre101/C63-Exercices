using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBill : MonoBehaviour
{
    public PlatformController PlatformController { get; private set; }
    private float destroyTimer;
    private Mario Mario;
    public Transform SpawnSmoke;
    private Health Health;

    private void Awake()
    {
        PlatformController = GetComponent<PlatformController>();
        PlatformController.OnWall += OnWall;
        Health = GetComponent<Health>();
        Health.OnDeath += OnDeath;
        Mario = GameManager.Instance.Mario;
        if (Mario.GetComponent<Transform>().position.x < gameObject.GetComponent<Transform>().position.x)
        {
            PlatformController.FacingController.Facing = Facing.Left;
        }
        else
        {
            PlatformController.FacingController.Facing = Facing.Right;
        }
        GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.Smoke, SpawnSmoke.position, gameObject.transform.rotation);
        destroyTimer = 0.1f;
    }

    private void OnDeath(Health hp)
    {
        Destroy(gameObject);
    }

    private void OnWall(PlatformController platformController)
    {
        if (destroyTimer <= 0.0f)
        {
            GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.Smoke, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        destroyTimer -= Time.deltaTime;
        PlatformController.InputMove = PlatformController.FacingController.Direction;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponentInParent<Health>();
        if (health)
        {
            var bulletPosition = PlatformController.BoxCollider2D.bounds.min.y + 0.5 * PlatformController.BoxCollider2D.bounds.extents.y;
            var marioPosition = collision.bounds.min.y;

            if (marioPosition < bulletPosition)
                health.Value -= 1;
            else
            {
                Health.Value -= 1;
                GameManager.Instance.SoundManager.Play(SoundManager.Sfx.Jump);
                Mario.PlatformController.Jump();
            }
        }
    }
}
