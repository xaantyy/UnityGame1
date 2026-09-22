using UnityEngine;

public class IntersectionZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        CarSplineMovement car = other.GetComponent<CarSplineMovement>();
        if (car != null)
        {
            car.SetInIntersection(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        CarSplineMovement car = other.GetComponent<CarSplineMovement>();
        if (car != null)
        {
            car.SetInIntersection(false);
        }
    }
}