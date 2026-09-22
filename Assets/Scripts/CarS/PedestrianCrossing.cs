using UnityEngine;

public class PedestrianCrossing : MonoBehaviour
{
    private CarSplineMovement _car;
    private bool _playerInZone = false;

    void OnTriggerEnter(Collider other)
    {
        CarSplineMovement foundCar = other.GetComponentInParent<CarSplineMovement>();

        if (foundCar != null)
        {
            _car = foundCar;
        }

        PlayerMovement player =
            other.GetComponentInParent<PlayerMovement>();

        if (player != null)
        {
            _playerInZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        PlayerMovement player =
            other.GetComponentInParent<PlayerMovement>();

        if (player != null)
        {
            _playerInZone = false;
        }
    }

    void Update()
    {
        if (_car == null)
        {
            return;
        }
        _car.SetStoppedByPedestrian(_playerInZone);
    }
}