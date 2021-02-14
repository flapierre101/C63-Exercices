using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
   
    public int HealthValue = 5;

    public int hpProp
    {
        get { return HealthValue; }
        set { HealthValue = value; }
    }

}
