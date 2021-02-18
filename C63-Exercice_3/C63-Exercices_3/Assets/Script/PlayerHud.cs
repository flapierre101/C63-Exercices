using System;
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
        player.Bomb.OnBombChanged += OnBombChanged;
        player.Score.OnScoreChanged += OnScoreChanged;

        OnHealthChanged(player.Health);
        OnBombChanged(player.Bomb);
        OnScoreChanged(player.Score);

    }

    private void OnScoreChanged(Score score)
    {
        PlayerScoreText.text = score.ScoreValue.ToString();
    }

    private void OnBombChanged(Bomb bomb)
    {
        PlayerBombText.text = "x " + bomb.BombValue.ToString();
    }

    private void OnHealthChanged(Health hp)
    {
        PlayerHealthText.text = "x " + hp.Value.ToString();
    }
}
