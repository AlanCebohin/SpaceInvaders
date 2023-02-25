using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int score;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        instance = this;
    }

    public void AddScore()
    {
        score++;
        AddScoreUI();
    }

    public void ResetScore()
    {
        score = 0;
    }

    private void AddScoreUI()
    {
        scoreText.text = score.ToString();
    }
}
