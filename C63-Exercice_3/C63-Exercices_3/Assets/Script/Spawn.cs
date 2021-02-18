using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float SpawnTimer = 5;
    private Player Player;
    private Health Health;

    void Awake()
    {
        Player = GameManager.Instance.Player;
        Health = GetComponent<Health>();
    }
    void Update()
    {
        SpawnTimer -= Time.deltaTime;
        if (SpawnTimer <= 0)
        {
            GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.monster2, transform.position, transform.rotation);
            GameManager.Instance.SoundManager.Play(SoundManager.Sfx.Spawn);
            SpawnTimer = 5;
        }
        if (Health.Value <= 0)
        {
            GameManager.Instance.SoundManager.Play(SoundManager.Sfx.Explosion);
            Destroy(gameObject);
        }
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
