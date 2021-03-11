using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPowerup : MonoBehaviour
{
    private bool isEmpty;

    public Animator Animator { get; private set; }
    public Transform PowerupSpawn;
    

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        Animator.Play("BlockPowerup");
        isEmpty = false;
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var mario = collision.gameObject.GetComponent<Mario>();
        if (collision.contacts[0].point.y <= (collision.otherCollider.bounds.min.y + 0.001f) && mario)
        {
            if (!isEmpty)
            {
                if (mario.CurrentState == Mario.State.Small)
                    GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.Mushroom, PowerupSpawn.position, transform.rotation);
                else if (mario.CurrentState == Mario.State.Big || mario.CurrentState == Mario.State.Fire)
                    GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.Flower, PowerupSpawn.position, transform.rotation);
                isEmpty = true;
                Animator.Play("BlockPowerup_Empty");
            }
            GameManager.Instance.SoundManager.Play(SoundManager.Sfx.Block);
            
        }

    }
}
