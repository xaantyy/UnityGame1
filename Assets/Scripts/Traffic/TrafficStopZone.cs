using UnityEngine;
using UnityEngine.Serialization;

public class TrafficStopZone : MonoBehaviour
{
    [FormerlySerializedAs("trafficLight")]
    [SerializeField] private TrafficLightController _trafficLight;

    [FormerlySerializedAs("goesEastWest")]
    [SerializeField] private bool _goesEastWest;

    private CarSplineMovement _car;

    void OnTriggerStay(Collider other)
    {
        if (other.isTrigger == true)
        {
            return;
        }

        CarSplineMovement foundCar =
            other.GetComponentInParent<CarSplineMovement>();

        if (foundCar != null)
        {
            _car = foundCar;
        }
    }

    void OnTriggerExit(Collider other)
    {
        CarSplineMovement foundCar =
            other.GetComponentInParent<CarSplineMovement>();

        if (foundCar != null && foundCar == _car)
        {
            _car.SetStoppedByLight(false);
            _car = null;
        }
    }

    void Update()
    {
        if (_car == null)
        {
            return;
        }

        if (_trafficLight.CanDrive(_goesEastWest) == false)
        {
            _car.SetStoppedByLight(true);
        }
        else
        {
            _car.SetStoppedByLight(false);
        }
    }
}