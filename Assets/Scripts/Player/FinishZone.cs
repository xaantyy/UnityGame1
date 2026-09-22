using UnityEngine;

public class FinishZone : MonoBehaviour
{
    public GameCycleManager gameCycleManager;
    public bool isPointA = true;

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(gameCycleManager.finishIsB);
        if (!other.CompareTag("Player"))
            return;

        if (isPointA && !gameCycleManager.finishIsB)
        {
            gameCycleManager.OnPlayerReachedFinish();
        }

        if (!isPointA && gameCycleManager.finishIsB)
        {
            gameCycleManager.OnPlayerReachedFinish();
        }
    }
}