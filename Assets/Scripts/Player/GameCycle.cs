using UnityEngine;

public class GameCycleManager : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _markerA;
    [SerializeField] private GameObject _markerB;
    [SerializeField] private bool _finishIsB = true;
    private CharacterController _controller;

    void Start()
    {
        _controller = _player.GetComponent<CharacterController>();
        MovePlayerToSpawn();
        UpdateMarkers();
    }

    void MovePlayerToSpawn()
    {
        _controller.enabled = false;

        if (_finishIsB)
        {
            _player.position = _pointA.position;
        }
        else
        {
            _player.position = _pointB.position;
        }
        _controller.enabled = true;
    }

    void UpdateMarkers()
    {
        _markerA.SetActive(!_finishIsB);
        _markerB.SetActive(_finishIsB);
    }

    public void OnPlayerReachedFinish()
    {
        _finishIsB = !_finishIsB;

        MovePlayerToSpawn();
        UpdateMarkers();
    }

    public bool GetFinishIsB()
    {
        return _finishIsB;
    }
}