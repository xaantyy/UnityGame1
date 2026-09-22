using UnityEngine;
using UnityEngine.Serialization;

public class CarCrosswalkStopZone : MonoBehaviour
{
    [FormerlySerializedAs("crossing")]
    [SerializeField] private UncontrolledCrossing _crossing;

    void OnTriggerStay(Collider other)
    {
        CarSplineMovement car =
            other.GetComponentInParent<CarSplineMovement>();

        if (car != null)
        {
            if (_crossing.GetCarsMustStop() == true)
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
        CarSplineMovement car =
            other.GetComponentInParent<CarSplineMovement>();

        if (car != null)
        {
            car.SetStoppedByPedestrian(false);
        }
    }
}