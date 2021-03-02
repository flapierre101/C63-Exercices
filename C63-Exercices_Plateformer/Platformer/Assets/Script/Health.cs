using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public delegate void HealthEvent(Health hp);
    public float InvincibilityTime = 0.1f;
    public float InvincibilityTimer { get; private set; }
    //Listener
    public HealthEvent OnChanged;
    public HealthEvent OnHit;
    public HealthEvent OnDeath;

    public int HealthValue;
    private int _value;

    public int Value
    {
        get { return _value; }
        set 
        {
            var previous = _value;
            _value = Mathf.Clamp(value, 0, HealthValue);

            if (_value != previous)
            {
                OnChanged?.Invoke(this);

                if (_value < previous)
                {
                    InvincibilityTimer = InvincibilityTime;
                    OnHit?.Invoke(this);
                }

                if (_value == 0)
                {
                    OnDeath?.Invoke(this);
                }
            }
            _value = value; 
        }
    }
    public bool CanBeDamaged
    {
        get
        {
            return InvincibilityTimer <= 0.0f;
        }
    }
    private void Awake()
    {
        Value = HealthValue;
    }
    private void Update()
    {
        InvincibilityTimer -= Time.deltaTime;
    }
}
