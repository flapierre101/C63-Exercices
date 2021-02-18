using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public delegate void BombEvent(Bomb bomb);

    //Listener
    public BombEvent OnBombChanged;

    public int StartBomb = 1;
    private int _startBomb;
    private float DestroyTimer = 1;
    private Flash flash;
    
    void Start()
    {
        flash = GetComponent<Flash>();
        flash.StartFlash();
    }

    private void Update()
    {
        DestroyTimer -= Time.deltaTime;
        if (DestroyTimer <= 0)
        {
            GameManager.Instance.SoundManager.Play(SoundManager.Sfx.Explosion);
            float tempo = 45.0f;
            for (int i = 1; i <= 8; i++)
            {
                var rotation1 = transform.rotation * Quaternion.Euler(0.0f, 0.0f, tempo * i);
                GameManager.Instance.PrefabManager.Instancier(PrefabManager.Global.bullet, gameObject.transform.position, rotation1);
            }

            Destroy(gameObject);
            GameManager.Instance.PrefabManager.Instancier
                (PrefabManager.Global.explosionBarrel, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
    private void Awake()
    {
        BombValue = StartBomb;
    }

    public int BombValue
    {
        get { return _startBomb; }
        set 
        {
            var previous = _startBomb;
            _startBomb = Mathf.Clamp(value, 0, StartBomb);
            if (_startBomb != previous)
            {
                OnBombChanged?.Invoke(this);
            }
            _startBomb = value; 
        }
    }
}
