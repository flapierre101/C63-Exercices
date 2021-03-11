using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerLevel : MonoBehaviour
{
    public SoundManager.Music Music = SoundManager.Music.Music;

    private void Awake()
    {
        GameManager.Instance.SoundManager.Play(Music);
    }
}
