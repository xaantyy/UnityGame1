using UnityEngine;

public class UncontrolledCrossing : MonoBehaviour
{
    public bool playerStopped = false;
    public bool carsMustStop = false;
    public float stopTime = 5f;

    float timer = 0f;

    public CarSplineMovement[] cars;

    void Update()
    {
        if (carsMustStop == true)
        {
            timer = timer + Time.deltaTime;

            if (timer >= stopTime)
            {
                carsMustStop = false;
                playerStopped = false;
                timer = 0f;

                for (int i = 0; i < cars.Length; i++)
                {
                    if (cars[i] != null)
                    {
                        cars[i].SetStoppedByPedestrian(false);
                    }
                }
            }
        }
    }

    public void StopCars()
    {
        if (carsMustStop == false)
        {
            playerStopped = true;
            carsMustStop = true;
            timer = 0f;
        }
    }
}