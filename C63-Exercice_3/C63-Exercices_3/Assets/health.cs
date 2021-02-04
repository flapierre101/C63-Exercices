using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    // Start is called before the first frame update
    public int _startHealth = 5;

    public int hpProp
    {
        get { return _startHealth; }
        set { _startHealth = value; }
    }

}
