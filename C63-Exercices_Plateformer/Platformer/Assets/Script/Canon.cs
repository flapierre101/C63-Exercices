using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public float fireTimer = 4;
    public PlatformController PlatformController { get; private set; }
    public Mario Mario;
    public Transform SpawnPoint;

    private void Awake()
    {
        Mario = GameManager.Instance.Mario;
    }


    void Update()
    {

        if (GameManager.Instance.IsInsideCamera(gameObject.GetComponent<SpriteRenderer>()))
        {
            fireTimer -= Time.deltaTime;
            if (fireTimer <= 0.0)
            {

                GameManager.Instance.SoundManager.Play(SoundManager.Sfx.Thwomp);
                GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.BulletBill, SpawnPoint.position, gameObject.transform.rotation);
                
                fireTimer = 4.0f;
            }
        }
    }
}
