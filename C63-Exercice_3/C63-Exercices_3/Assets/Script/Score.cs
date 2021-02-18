using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public delegate void ScoreEvent(Score score);

    //Listener
    public ScoreEvent OnScoreChanged;

    //private int ScoreTotal;
    private int _score;

    public int ScoreValue
    {
        get { return _score; }
        set 
        {
            OnScoreChanged?.Invoke(this);
            _score = value; 
        }
    }
}
