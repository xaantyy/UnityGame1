using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class UncontrolledWaitZone : MonoBehaviour
{
    [FormerlySerializedAs("crossing")]
    [SerializeField] private UncontrolledCrossing _crossing;

    private InputService _inputService;
    private float _timer = 0f;
    private bool _used = false;

    [Inject]
    public void Construct(InputService inputService)
    {
        _inputService = inputService;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_used == true)
            {
                return;
            }

            Vector2 input = _inputService.GetMoveDirection();

            if (input == Vector2.zero)
            {
                _timer = _timer + Time.deltaTime;
            }
            else
            {
                _timer = 0f;
            }

            if (_timer >= 0.5f)
            {
                _crossing.StopCars();
                _used = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _timer = 0f;
            _used = false;
        }
    }
}