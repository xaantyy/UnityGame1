using UnityEngine;
public class CarObstacle : MonoBehaviour
{
    CarSplineMovement myCar;
    float timer = 0f;
    void Start()
    {
        myCar = GetComponentInParent<CarSplineMovement>();
    }

    void Update()
    {
        if (myCar.GetIsInIntersection() == true)
        {
            myCar.SetStoppedByObstacle(false);
            timer = 0f;
            return;
        }

        timer = timer - Time.deltaTime;

        if (timer > 0f)
        {
            myCar.SetStoppedByObstacle(true);
        }
        else
        {
            myCar.SetStoppedByObstacle(false);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            CarSplineMovement otherCar =
                other.GetComponentInParent<CarSplineMovement>();

            if (otherCar != null && otherCar != myCar)
            {
                timer = 0.3f;
            }
        }
    }
}