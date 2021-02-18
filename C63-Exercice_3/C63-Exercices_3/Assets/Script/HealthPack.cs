using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collider)
    {
        var Player = GameManager.Instance.Player;
        if (Player.gameObject == collider.gameObject && Player.Health.Value < 5)
        {
            Player.Health.Value++;

            Destroy(gameObject);  
        }
    }
}
