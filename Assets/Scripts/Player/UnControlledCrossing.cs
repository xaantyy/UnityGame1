using UnityEngine;
using UnityEngine.Serialization;

public class UncontrolledCrossing : MonoBehaviour
{
    [FormerlySerializedAs("stopTime")]
    [SerializeField] private float _stopTime = 5f;

    [FormerlySerializedAs("cars")]
    [SerializeField] private CarSplineMovement[] _cars;

    private bool _playerStopped = false;
    private bool _carsMustStop = false;
    private float _timer = 0f;

    void Update()
    {
        if (_carsMustStop == true)
        {
            _timer = _timer + Time.deltaTime;

            if (_timer >= _stopTime)
            {
                _carsMustStop = false;
                _playerStopped = false;
                _timer = 0f;

                for (int i = 0; i < _cars.Length; i++)
                {
                    if (_cars[i] != null)
                    {
                        _cars[i].SetStoppedByPedestrian(false);
                    }
                }
            }
        }
    }

    public void StopCars()
    {
        if (_carsMustStop == false)
        {
            _playerStopped = true;
            _carsMustStop = true;
            _timer = 0f;
        }
    }

    public bool GetPlayerStopped()
    {
        return _playerStopped;
    }

    public bool GetCarsMustStop()
    {
        return _carsMustStop;
    }
}