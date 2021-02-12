using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collider)
    {
        var Player = collider.gameObject.GetComponentInParent<Player>();
        if (Player != null && Player.gameObject.GetComponentInParent<health>().hpProp < 5)
        {
            Player.gameObject.GetComponentInParent<health>().hpProp++;

            Destroy(gameObject);
            
        }
    }
}
