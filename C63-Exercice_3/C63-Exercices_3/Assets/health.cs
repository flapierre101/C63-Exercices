using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    // Start is called before the first frame update
    public int HealthValue = 5;

    public int hpProp
    {
        get { return HealthValue; }
        set { HealthValue = value; }
    }

}
