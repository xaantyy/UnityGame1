using UnityEngine;
using Zenject;

public class PedestrianZone : MonoBehaviour
{
    public TrafficLightController trafficLight;
    public bool crossingEastWestRoad = true;
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
            if (trafficLight.CanWalk(crossingEastWestRoad) == false)
            {
                _scoreManager.RedLightPenalty();
            }
        }
    }
}