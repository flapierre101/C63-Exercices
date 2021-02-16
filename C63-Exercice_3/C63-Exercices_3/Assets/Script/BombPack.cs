using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPack : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collider)
    {
        var Player = collider.gameObject.GetComponentInParent<Player>();
        if (Player != null && Player.gameObject.GetComponentInParent<Bomb>().BombProp < 3)
        {
            Player.gameObject.GetComponentInParent<Bomb>().BombProp++;

            Destroy(gameObject);

        }
    }
}
