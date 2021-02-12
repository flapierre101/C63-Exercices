using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    public Player Player;
    public Text PlayerBombText;
    public Text PlayerHealthText;
    public Text PlayerScoreText;
    void Start()
    {
        
    }

 
    void Update()
    {
        PlayerBombText.text = Player.GetComponent<Bomb>()._startBomb.ToString();
        PlayerHealthText.text = Player.GetComponent<health>().HealthValue.ToString();
        //PlayerScoreText = Player.GetComponent<Score>().GameScore.ToString();
    }
}
