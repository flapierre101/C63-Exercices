using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public delegate void HealthEvent(Health hp);

    //Listener
    public HealthEvent OnChanged;
    public HealthEvent OnHit;
    public HealthEvent OnDeath;

    public int HealthValue = 5;

  
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
                    OnHit?.Invoke(this);
                }

                if (_value <= 0)
                {
                    OnDeath?.Invoke(this);
                }
            }
            _value = value; 
         
        }
    }
    private void Awake()
    {
        Value = HealthValue;
    }

}
