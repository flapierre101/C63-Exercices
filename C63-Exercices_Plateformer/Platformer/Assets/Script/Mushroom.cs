using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public PlatformController PlatformController { get; private set; }
    private Mario mario;

    private void Awake()
    {
        mario = GameManager.Instance.Mario;
        PlatformController = GetComponent<PlatformController>();
        PlatformController.OnWall += OnWall;
        PlatformController.FacingController.Facing = Facing.Right;
    }

    private void OnWall(PlatformController platformController)
    {
        PlatformController.FacingController.Flip();
        PlatformController.InputMove = PlatformController.FacingController.Direction;
    }
    private void Update()
    {
        PlatformController.InputMove = PlatformController.FacingController.Direction;
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
                if (mario.Health.Value == 1)
                    mario.Health.Value += 1;
            }
        }
    }
}
