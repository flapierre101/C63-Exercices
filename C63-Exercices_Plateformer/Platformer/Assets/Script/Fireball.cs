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
        GameManager.Instance.SoundManager.Play(SoundManager.Sfx.EnemyFireball);
        GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.Puff, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void Update()
    {
        PlatformController.InputMove = PlatformController.FacingController.Direction;
        PlatformController.InputJump = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponentInParent<Health>();
        if (health)
        {
            if (!collision.GetComponent<Mario>())
            {
                health.Value -= 1;
                GameManager.Instance.SoundManager.Play(SoundManager.Sfx.EnemyFireball);
                GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.Puff, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
