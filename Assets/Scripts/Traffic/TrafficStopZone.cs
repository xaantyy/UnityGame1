using UnityEngine;

public class TrafficStopZone : MonoBehaviour
{
    public TrafficLightController trafficLight;
    public bool goesEastWest;

    void OnTriggerStay(Collider other)
    {
        if (other.isTrigger == true)
        {
            return;
        }

        CarSplineMovement car =
            other.GetComponentInParent<CarSplineMovement>();

        if (car != null)
        {
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
    void OnTriggerExit(Collider other)
    {
        if (other.isTrigger == true)
        {
            return;
        }

        CarSplineMovement car =
            other.GetComponentInParent<CarSplineMovement>();

        if (car != null)
        {
            car.SetStoppedByLight(false);
        }
    }
}