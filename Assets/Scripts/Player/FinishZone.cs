using UnityEngine;

public class FinishZone : MonoBehaviour
{
    [SerializeField] private GameCycleManager _gameCycleManager;
    [SerializeField] private bool _isPointA = true;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (_isPointA && !_gameCycleManager.GetFinishIsB())
        {
            _gameCycleManager.OnPlayerReachedFinish();
        }

        if (!_isPointA && _gameCycleManager.GetFinishIsB())
        {
            _gameCycleManager.OnPlayerReachedFinish();
        }
    }
}