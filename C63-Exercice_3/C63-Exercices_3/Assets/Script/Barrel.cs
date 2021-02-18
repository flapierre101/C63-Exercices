using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public Health Health;
    public float DestroyTimer = 2;
    private Flash flash;

    void Start()
    {
        Health = GetComponent<Health>();
        flash = GetComponent<Flash>();
    }

    void Update()
    {
        if (flash.enabled)
        {
            DestroyTimer -= Time.deltaTime;
            if (DestroyTimer <= 0)
            {
                float tempo = 45.0f;
                for (int i = 1; i <= 8; i++)
                {
                    var rotation1 = transform.rotation * Quaternion.Euler(0.0f, 0.0f, tempo*i);
                    GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.bullet, gameObject.transform.position, rotation1);
                }
                GameManager.Instance.SoundManager.Play(SoundManager.Sfx.Explosion);
                Destroy(gameObject);
                GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.explosionBarrel, gameObject.transform.position, gameObject.transform.rotation);
            }
        }

        if (Health.Value == 0)
            if (!flash.enabled)
                flash.StartFlash();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            Health.Value -= 1;
            GameManager.Instance.SoundManager.Play(SoundManager.Sfx.Pistol);
            Destroy(collision.gameObject);
        }
    }
}
