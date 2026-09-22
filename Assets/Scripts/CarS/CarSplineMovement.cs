using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.Serialization; //сохзранить ссылку
public class CarSplineMovement : MonoBehaviour
{
    private enum CarState
    {
        Driving,
        StoppedByLight,
        StoppedByObstacle,
        StoppedByPedestrian
    }
    private CarState _state = CarState.Driving;
    [FormerlySerializedAs("spline")]
    [SerializeField] private SplineContainer _spline;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _acceleration = 10f;
    [SerializeField] private float _brakePower = 2f;
    private bool _stoppedByLight;
    private bool _stoppedByObstacle;
    private bool _stoppedByPedestrian;
    private bool _isInIntersection;
    private float _currentSpeed = 0f;
    private float _t = 0f;
    private float _splineLength;

    void Start()
    {
        _splineLength = _spline.CalculateLength();
    }

    void Update()
    {
        UpdateState();
        ChangeSpeed();
        MoveCar();
    }

    void ChangeSpeed()
    {
        if (_state != CarState.Driving)
        {
            _currentSpeed = _currentSpeed - _acceleration * _brakePower * Time.deltaTime;

            if (_currentSpeed < 0f)
            {
                _currentSpeed = 0f;
            }
        }
        else
        {
            _currentSpeed = _currentSpeed + _acceleration * Time.deltaTime;

            if (_currentSpeed > _speed)
            {
                _currentSpeed = _speed;
            }
        }
    }

    void MoveCar()
    {
        if (_currentSpeed <= 0f)
        {
            return;
        }

        _t = _t + _currentSpeed * Time.deltaTime / _splineLength;

        if (_t > 1f)
        {
            _t = 0f;
        }

        transform.position = _spline.EvaluatePosition(_t);

        Vector3 direction = _spline.EvaluateTangent(_t);

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    public Vector3 GetFutureDirection(float secondsAhead)
    {
        float futureT = _t + _currentSpeed * secondsAhead / _splineLength;

        if (futureT > 1f)
        {
            futureT = futureT - 1f;
        }

        Vector3 futureDirection = _spline.EvaluateTangent(futureT);

        return futureDirection.normalized;
    }

    public float GetStoppingDistance()
    {
        return _currentSpeed * _currentSpeed / (2f * _brakePower);
    }

    public void SetStoppedByObstacle(bool value)
    {
        _stoppedByObstacle = value;
    }
    public void SetStoppedByLight(bool value)
    {
        _stoppedByLight = value;
    }
    public void SetStoppedByPedestrian(bool value)
    {
        _stoppedByPedestrian = value;
    }

    public void SetInIntersection(bool value)
    {
        _isInIntersection = value;
    }

    public bool GetIsInIntersection()
    {
        return _isInIntersection;
    }

    void UpdateState()
    {
        if (_stoppedByPedestrian == true)
        {
            _state = CarState.StoppedByPedestrian;
        }
        else if (_stoppedByObstacle == true)
        {
            _state = CarState.StoppedByObstacle;
        }
        else if (_stoppedByLight == true)
        {
            _state = CarState.StoppedByLight;
        }
        else
        {
            _state = CarState.Driving;
        }
    }
}