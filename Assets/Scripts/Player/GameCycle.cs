using UnityEngine;

public class GameCycleManager : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform player;
    public GameObject markerA;
    public GameObject markerB;
    public bool finishIsB = true;
    CharacterController controller;

    void Start()
    {
        controller = player.GetComponent<CharacterController>();
        MovePlayerToSpawn();
        UpdateMarkers();
    }

    void MovePlayerToSpawn()
    {
        controller.enabled = false;

        if (finishIsB)
        {
            player.position = pointA.position;
        }
        else
        {
            player.position = pointB.position;
        }

        controller.enabled = true;
    }
    void UpdateMarkers()
    {
        markerA.SetActive(!finishIsB);
        markerB.SetActive(finishIsB);
    }
    public void OnPlayerReachedFinish()
    {
        finishIsB = !finishIsB;
        MovePlayerToSpawn();
        UpdateMarkers();
    }
}