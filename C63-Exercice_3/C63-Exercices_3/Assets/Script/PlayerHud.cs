using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{

    public Text PlayerBombText;
    public Text PlayerHealthText;
    public Text PlayerScoreText;
    void Start()
    {
        var player = GameManager.Instance.Player;
        player.Health.OnChanged += OnHealthChanged;
        //player.Bomb.OnChanged += OnBombChanged;
        //player.Score.OnChanged += OnScoreChanged;

        OnHealthChanged(player.Health);
        //OnBombChanged(player.Bomb);
        //OnScoreChanged(player.Score);

    }

    private void OnHealthChanged(Health hp)
    {
        PlayerHealthText.text = hp.Value.ToString();
    }
    //private void OnBombChanged(Bomb bomb)
    //{
    //    PlayerBombText.text = "x " + bomb.Value.ToString();
    //}    
    //private void OnScoreChanged(Score score)
    //{
    //    PlayerScoreText.text = score.Value.ToString();
    //}
//    void Update()
//    {
//        PlayerBombText.text = GameManager.Instance.Player.GetComponent<Bomb>()._startBomb.ToString();
//        //PlayerHealthText.text = GameManager.Instance.Player.GetComponent<Health>().HealthValue.ToString();
//        PlayerScoreText.text = GameManager.Instance.Player.GetComponent<Score>().ScoreProp.ToString();
//    }
}
