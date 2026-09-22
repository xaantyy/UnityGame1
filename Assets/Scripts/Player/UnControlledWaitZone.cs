using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class UncontrolledWaitZone : MonoBehaviour
{
    [FormerlySerializedAs("crossing")]
    [SerializeField] private UncontrolledCrossing _crossing;
    private InputService _inputService;
    private bool _playerInZone = false;
    private bool _used = false;
    [Inject]
    public void Construct(InputService inputService)
    {
        _inputService = inputService;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInZone = true;
            WaitForStop().Forget();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInZone = false;
            _used = false;
        }
    }

    async UniTask WaitForStop()
    {
        while (_playerInZone == true && _used == false)
        {
            await UniTask.WaitUntil(() =>
                _inputService.GetMoveDirection() == Vector2.zero ||
                _playerInZone == false);

            if (_playerInZone == false)
            {
                return;
            }

            await UniTask.Delay(500);

            if (_inputService.GetMoveDirection() == Vector2.zero &&
                _playerInZone == true)
            {
                _crossing.StopCars();
                _used = true;
            }
        }
    }
}