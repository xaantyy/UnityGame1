using UnityEngine;
using Zenject;
public class PenaltyZone : MonoBehaviour
{
    private ScoreManager _scoreManager;
    [Inject]
    private void Construct(ScoreManager scoreManager)
    {
        _scoreManager = scoreManager;
    }
    private float _timer = 0f;
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _timer = _timer + Time.deltaTime;

            if (_timer >= 1f)
            {
                _scoreManager.AddPenalty(7);
                _timer = 0f;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _timer = 0f;
        }
    }
}