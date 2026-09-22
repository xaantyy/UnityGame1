using UnityEngine;

public class UncontrolledWaitZone : MonoBehaviour
{
    public UncontrolledCrossing crossing;
    float timer = 0f;
    bool used = false;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (used == true)
            {
                return;
            }

            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                timer = 0f;
            }

            if (timer >= 0.5f)
            {
                crossing.StopCars();
                used = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer = 0f;
            used = false;
        }
    }
}