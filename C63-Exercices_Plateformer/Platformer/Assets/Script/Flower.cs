using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public PlatformController PlatformController { get; private set; }
    private Mario mario;

    private void Awake()
    {
        mario = GameManager.Instance.Mario;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == mario.gameObject)
        {
            Destroy(gameObject);
            if (mario.CurrentState == Mario.State.Small)
            {
                GameManager.Instance.SoundManager.Play(SoundManager.Sfx.Powerup);
                mario.CurrentState = Mario.State.Big;
            }
            else if (mario.CurrentState == Mario.State.Big)
            {
                GameManager.Instance.SoundManager.Play(SoundManager.Sfx.Powerup);
                mario.CurrentState = Mario.State.Fire;
            }
        }
    }
}
