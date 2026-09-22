using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class UncontrolledZebraZone : MonoBehaviour
{
    [FormerlySerializedAs("crossing")]
    [SerializeField] private UncontrolledCrossing _crossing;
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
            if (_crossing.GetPlayerStopped() == false)
            {
                _scoreManager.RoadPenalty();
            }
        }
    }
}