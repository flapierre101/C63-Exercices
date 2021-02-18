using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 1;
    private Player Player;
    public Health Health;

    void Awake()
    {
        Player = GameManager.Instance.Player;
        Health = GetComponent<Health>();
        Health.OnDeath += Ondeath;
    }

    private void Ondeath(Health hp)
    {
        if (hp.Value <= 0)
        {
            GameManager.Instance.SoundManager.Play(SoundManager.Sfx.Explosion);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.position =  Vector3.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
        transform.right = Player.transform.position - transform.position;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
          
            Health.Value -= 1;
            Player.Score.ScoreValue += 25;

            GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.explosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            GameManager.Instance.SoundManager.Play(SoundManager.Sfx.Pistol);
            Destroy(collision.gameObject);
            
        }
    }
}
