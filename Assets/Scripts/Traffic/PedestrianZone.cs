using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class PedestrianZone : MonoBehaviour
{
    [FormerlySerializedAs("trafficLight")]
    [SerializeField] private TrafficLightController _trafficLight;
    [FormerlySerializedAs("crossingEastWestRoad")]
    [SerializeField] private bool _crossingEastWestRoad = true;
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
            if (_trafficLight.CanWalk(_crossingEastWestRoad) == false)
            {
                _scoreManager.RedLightPenalty();
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