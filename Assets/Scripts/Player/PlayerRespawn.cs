using UnityEngine;
using Zenject;
public class PlayerRespawn : MonoBehaviour
{
    public Transform[] safeZones;
    private ScoreManager _scoreManager;
    [Inject]
    public void Construct(ScoreManager scoreManager)
    {
        _scoreManager = scoreManager;
    }
    CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        CarSplineMovement car = hit.collider.GetComponentInParent<CarSplineMovement>();

        if (car != null)
        {
            _scoreManager.CrashPenalty();
            Respawn();
        }
    }

    void Respawn()
    {
        Transform nearestZone = safeZones[0];

        for (int i = 0; i < safeZones.Length; i++)
        {
            float distanceToZone =
                Vector3.Distance(transform.position, safeZones[i].position);

            float distanceToNearest =
                Vector3.Distance(transform.position, nearestZone.position);

            if (distanceToZone < distanceToNearest)
            {
                nearestZone = safeZones[i];
            }
        }
        controller.enabled = false;
        transform.position = nearestZone.position;
        controller.enabled = true;
    }
}