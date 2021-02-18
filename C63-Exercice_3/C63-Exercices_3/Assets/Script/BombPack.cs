using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPack : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collider)
    {
        var Player = GameManager.Instance.Player;
        if (Player.gameObject == collider.gameObject && Player.gameObject.GetComponentInParent<Bomb>().BombValue < 3)
        {
            Player.Bomb.BombValue++;

            Destroy(gameObject);
        }
    }
}
