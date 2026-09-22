using UnityEngine;

public class CarCrosswalkStopZone : MonoBehaviour
{
    public UncontrolledCrossing crossing;

    void OnTriggerStay(Collider other)
    {
        CarSplineMovement car = other.GetComponentInParent<CarSplineMovement>();

        if (car != null)
        {
            if (crossing.carsMustStop == true)
            {
                car.SetStoppedByPedestrian(true);
            }
            else
            {
                car.SetStoppedByPedestrian(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        CarSplineMovement car = other.GetComponentInParent<CarSplineMovement>();

        if (car != null)
        {
            car.SetStoppedByPedestrian(false);
        }
    }
}