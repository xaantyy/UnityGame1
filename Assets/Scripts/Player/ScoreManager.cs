using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int _score = 100;
    [SerializeField] private TextMeshProUGUI _scoreText;

    void Start()
    {
        UpdateScoreText();
    }

    public void RedLightPenalty()
    {
        AddPenalty(10);
    }

    public void RoadPenalty()
    {
        AddPenalty(15);
    }

    public void CrashPenalty()
    {
        AddPenalty(25);
    }

    public void AddPenalty(int amount)
    {
        _score = _score - amount;

        if (_score < 0)
        {
            _score = 0;
        }

        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        _scoreText.text = "очки: " + _score;
    }
}