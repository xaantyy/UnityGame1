using UnityEngine;
public class CarObstacle : MonoBehaviour
{
    private CarSplineMovement _myCar;
    private float _timer = 0f;
    void Start()
    {
        _myCar = GetComponentInParent<CarSplineMovement>();
    }

    void Update()
    {
        if (_myCar.GetIsInIntersection() == true)
        {
            _myCar.SetStoppedByObstacle(false);
            _timer = 0f;
            return;
        }

        _timer = _timer - Time.deltaTime;

        if (_timer > 0f)
        {
            _myCar.SetStoppedByObstacle(true);
        }
        else
        {
            _myCar.SetStoppedByObstacle(false);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            CarSplineMovement otherCar =
                other.GetComponentInParent<CarSplineMovement>();

            if (otherCar != null && otherCar != _myCar)
            {
                _timer = 0.3f;
            }
        }
    }
}