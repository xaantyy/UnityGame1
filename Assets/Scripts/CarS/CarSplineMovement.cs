using UnityEngine;
using UnityEngine.Splines;

public class CarSplineMovement : MonoBehaviour
{
    public SplineContainer spline;
    [SerializeField] private float _speed = 10f;
    public float acceleration = 10f;
    public float brakePower = 3f;
    private bool _shouldStop;
    private bool _stoppedByLight;
    private bool _stoppedByObstacle;
    private bool _stoppedByPedestrian;
    private bool _isInIntersection;

    float currentSpeed = 0f;
    float t = 0f;
    float splineLength;

    void Start()
    {
        splineLength = spline.CalculateLength();
    }

    void Update()
    {
        CheckStop();
        ChangeSpeed();
        MoveCar();
    }

    void CheckStop()
    {
        _shouldStop =
            _stoppedByLight ||
            _stoppedByObstacle ||
            _stoppedByPedestrian;
    }

    void ChangeSpeed()
    {
        if (_shouldStop)
        {
            currentSpeed = currentSpeed - brakePower * Time.deltaTime;

            if (currentSpeed < 0f)
            {
                currentSpeed = 0f;
            }
        }
        else
        {
            currentSpeed = currentSpeed + acceleration * Time.deltaTime;

            if (currentSpeed > _speed)
            {
                currentSpeed = _speed;
            }
        }
    }

    void MoveCar()
    {
        if (currentSpeed <= 0f)
        {
            return;
        }

        t = t + currentSpeed * Time.deltaTime / splineLength;

        if (t > 1f)
        {
            t = 0f;
        }

        transform.position = spline.EvaluatePosition(t);

        Vector3 direction = spline.EvaluateTangent(t);

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    public Vector3 GetFutureDirection(float secondsAhead)
    {
        float futureT = t + currentSpeed * secondsAhead / splineLength;

        if (futureT > 1f)
        {
            futureT = futureT - 1f;
        }

        Vector3 futureDirection = spline.EvaluateTangent(futureT);

        return futureDirection.normalized;
    }

    public float GetStoppingDistance()
    {
        return currentSpeed * currentSpeed / (2f * brakePower);
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
}