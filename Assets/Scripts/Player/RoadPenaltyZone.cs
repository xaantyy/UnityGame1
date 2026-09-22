using UnityEngine;
using Zenject;

public class PenaltyZone : MonoBehaviour
{
    private ScoreManager _scoreManager;

    private float _timer = 0f;
    private bool _playerInZone = false;
    [Inject]
    private void Construct(ScoreManager scoreManager)
    {
        _scoreManager = scoreManager;
    }

    void Update()
    {
        if (_playerInZone == true)
        {
            _timer = _timer + Time.deltaTime;

            if (_timer >= 1f)
            {
                _scoreManager.AddPenalty(7);
                _timer = 0f;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInZone = false;
            _timer = 0f;
        }
    }
}