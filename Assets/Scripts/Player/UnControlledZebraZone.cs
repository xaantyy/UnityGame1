using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class UncontrolledZebraZone : MonoBehaviour
{
    [FormerlySerializedAs("crossing")]
    [SerializeField] private UncontrolledCrossing _crossing;
    private ScoreManager _scoreManager;
    private bool _checkPenalty = false;
    [Inject]
    public void Construct(ScoreManager scoreManager)
    {
        _scoreManager = scoreManager;
    }

    void Update()
    {
        if (_checkPenalty == true)
        {
            if (_crossing.GetPlayerStopped() == false)
            {
                _scoreManager.RoadPenalty();
            }
            _checkPenalty = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _checkPenalty = true;
        }
    }
}