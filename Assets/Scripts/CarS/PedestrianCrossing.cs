using UnityEngine;

public class PedestrianCrossing : MonoBehaviour
{
    private CarSplineMovement car;
    private bool playerInZone = false;

    void OnTriggerEnter(Collider other)
    {
        CarSplineMovement foundCar = other.GetComponentInParent<CarSplineMovement>();
        if (foundCar != null)
        {
            car = foundCar;
        }

        PlayerMovement player = other.GetComponentInParent<PlayerMovement>();
        if (player != null)
        {
            playerInZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        PlayerMovement player = other.GetComponentInParent<PlayerMovement>();
        if (player != null)
        {
            playerInZone = false;
        }
    }

    void Update()
    {
        if (car == null)
            return;

        car.SetStoppedByPedestrian(playerInZone);
    }
}