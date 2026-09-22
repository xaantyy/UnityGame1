using UnityEngine;
using Zenject;

public class UncontrolledZebraZone : MonoBehaviour
{
    public UncontrolledCrossing crossing;
    private ScoreManager _scoreManager;
    [Inject]
    public void Construct(ScoreManager scoreManager)
    {
        _scoreManager = scoreManager;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (crossing.playerStopped == false)
            {
                _scoreManager.RoadPenalty();
            }
        }
    }
}