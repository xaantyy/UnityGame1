using UnityEngine;

public class TrafficStopZone : MonoBehaviour
{
    public TrafficLightController trafficLight;
    public bool goesEastWest;

    private CarSplineMovement car;

    void OnTriggerStay(Collider other)
    {
        if (other.isTrigger == true)
            return;

        CarSplineMovement foundCar =
            other.GetComponentInParent<CarSplineMovement>();

        if (foundCar != null)
        {
            car = foundCar;
        }
    }

    void OnTriggerExit(Collider other)
    {
        CarSplineMovement foundCar =
            other.GetComponentInParent<CarSplineMovement>();

        if (foundCar != null && foundCar == car)
        {
            car.SetStoppedByLight(false);
            car = null;
        }
    }

    void Update()
    {
        if (car == null)
            return;

        if (trafficLight.CanDrive(goesEastWest) == false)
        {
            car.SetStoppedByLight(true);
        }
        else
        {
            car.SetStoppedByLight(false);
        }
    }
}