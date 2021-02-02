using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    public AudioSource audioSource;

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
        Destroy(gameObject);
    }
}
