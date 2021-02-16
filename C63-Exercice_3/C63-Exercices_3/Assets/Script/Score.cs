using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int ScoreTotal = 0;

    public int ScoreProp
    {
        get { return ScoreTotal; }
        set { ScoreTotal = value; }
    }
}
