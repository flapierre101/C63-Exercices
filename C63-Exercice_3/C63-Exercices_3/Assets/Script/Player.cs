using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform BulletSpawnPoint;
    public float InvincibleTimer = 0;

    public Health Health { get; private set; }
    public Flash Flash { get; private set; }
    public Bomb Bomb { get; private set; }
    public Score Score { get; private set; }

    private void Awake()
    {
        Health = GetComponent<Health>();
        Health.OnHit += OnHit;
        Health.OnDeath += OnDeath;
        Flash = GetComponent<Flash>();
        Bomb = GetComponent<Bomb>();
        Score = GetComponent<Score>();
    }

    private void OnDeath(Health hp)
    {
        GameManager.Instance.SoundManager.Play(SoundManager.Sfx.Explosion);
        gameObject.SetActive(false);
    }

    private void OnHit(Health hp)
    {
        InvincibleTimer = 2;
        Flash.StartFlash();
        GameManager.Instance.SoundManager.Play(SoundManager.Sfx.Hit);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.bullet, BulletSpawnPoint.position, transform.rotation);
            GameManager.Instance.SoundManager.Play(SoundManager.Sfx.Pistol);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            var rotation1 = transform.rotation * Quaternion.Euler(0.0f, 0.0f, -30.0f);
            var rotation2 = transform.rotation * Quaternion.Euler(0.0f, 0.0f, 30.0f);
            GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.bullet, BulletSpawnPoint.position, transform.rotation);
            GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.bullet, BulletSpawnPoint.position, rotation1);
            GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.bullet, BulletSpawnPoint.position, rotation2);
            GameManager.Instance.SoundManager.Play(SoundManager.Sfx.Shotgun);
        }
        else if (Input.GetMouseButtonDown(2))
        {
            if (Bomb.BombValue > 0)
            {
                GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.bomb, BulletSpawnPoint.position, transform.rotation);
                Bomb.BombValue -= 1;
            }
        }
        if (InvincibleTimer > 0)
        {
            InvincibleTimer -= Time.deltaTime;
        }
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        var enemy = collider.gameObject.GetComponentInParent<Enemy>();
        if (enemy != null && InvincibleTimer <= 0)
            if (Health.Value > 0)
                Health.Value -= 1;
    }
}
