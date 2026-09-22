using UnityEngine;
using Zenject;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform[] _safeZones;
    private ScoreManager _scoreManager;
    private CharacterController _controller;

    [Inject]
    public void Construct(ScoreManager scoreManager)
    {
        _scoreManager = scoreManager;
    }

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        CarSplineMovement car =
            hit.collider.GetComponentInParent<CarSplineMovement>();

        if (car != null)
        {
            _scoreManager.CrashPenalty();
            Respawn();
        }
    }

    void Respawn()
    {
        Transform nearestZone = _safeZones[0];

        for (int i = 0; i < _safeZones.Length; i++)
        {
            float distanceToZone =
                Vector3.Distance(transform.position, _safeZones[i].position);

            float distanceToNearest =
                Vector3.Distance(transform.position, nearestZone.position);

            if (distanceToZone < distanceToNearest)
            {
                nearestZone = _safeZones[i];
            }
        }
        _controller.enabled = false;
        transform.position = nearestZone.position;
        _controller.enabled = true;
    }
}