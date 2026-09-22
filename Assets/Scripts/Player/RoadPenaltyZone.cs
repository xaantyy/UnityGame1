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
    float timer = 0f;
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer = timer + Time.deltaTime;

            if (timer >= 1f)
            {
                _scoreManager.AddPenalty(7);
                timer = 0f;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer = 0f;
        }
    }
}