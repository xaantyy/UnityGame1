using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CarCrosswalkStopZone : MonoBehaviour
{
    [FormerlySerializedAs("crossing")]
    [SerializeField] private UncontrolledCrossing _crossing;

    private List<CarSplineMovement> _cars =
        new List<CarSplineMovement>();

    void Update()
    {
        for (int i = 0; i < _cars.Count; i++)
        {
            if (_crossing.GetCarsMustStop() == true)
            {
                _cars[i].SetStoppedByPedestrian(true);
            }
            else
            {
                _cars[i].SetStoppedByPedestrian(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        CarSplineMovement car =
            other.GetComponentInParent<CarSplineMovement>();

        if (car != null && _cars.Contains(car) == false)
        {
            _cars.Add(car);
        }
    }

    void OnTriggerExit(Collider other)
    {
        CarSplineMovement car =
            other.GetComponentInParent<CarSplineMovement>();

        if (car != null)
        {
            car.SetStoppedByPedestrian(false);
            _cars.Remove(car);
        }
    }
}