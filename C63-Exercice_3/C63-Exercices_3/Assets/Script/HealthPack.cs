using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collider)
    {
        var Player = collider.gameObject.GetComponentInParent<Player>();
        if (Player != null && Player.Health.Value < 5)
        {
            Player.gameObject.GetComponentInParent<Health>().Value++;

            Destroy(gameObject);
            
        }
    }
}
