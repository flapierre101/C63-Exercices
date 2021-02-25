using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle2 : MonoBehaviour
{
    public PlatformController PlatformController { get; private set; }
    public Health Health { get; private set; }

    //private float _jumpTimer;

    private void Awake()
    {
        PlatformController = GetComponent<PlatformController>();
        PlatformController.OnWall += OnWall;
        Health = GetComponent<Health>();
        Health.OnDeath += OnDeath;
    }

    private void OnDeath(Health hp)
    {

        GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.Turtle1, gameObject.transform.position,
                    gameObject.transform.rotation);
        Destroy(gameObject);
    }

    private void OnWall(PlatformController platformController)
    {
        PlatformController.FacingController.Flip();
        PlatformController.InputMove = PlatformController.FacingController.Direction;
    }

    private void Update()
    {
        PlatformController.InputMove = PlatformController.FacingController.Direction;
        if (PlatformController.IsGrounded)
        {
            PlatformController.Jump();
            //_jumpTimer = 0.7f;
        }
        //_jumpTimer -= Time.deltaTime;
    }
}
