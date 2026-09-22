using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 100;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText.text = "очки: " + score;
    }

    public void RedLightPenalty()
    {
        score = score - 10;

        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = "очки: " + score;
    }

    public void RoadPenalty()
    {
        score = score - 15;

        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = "очки: " + score;
    }

    public void AddPenalty(int amount)
    {
        score = score - amount;

        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = "очки: " + score;
    }

    public void CrashPenalty()
    {
        score = score - 25;

        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = "очки: " + score;
    }
}