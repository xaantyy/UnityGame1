using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private InputService _inputService;
    [Inject]
    public void Construct(InputService inputService)
    {
        _inputService = inputService;
    }
    [SerializeField] private float _speed = 28f;
    [SerializeField] private float _minX = -50f;
    [SerializeField] private float _maxX = 50f;
    [SerializeField] private float _minZ = -50f;
    [SerializeField] private float _maxZ = 50f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 input = _inputService.GetMoveDirection();
        Vector3 direction = new Vector3(input.x, 0f, input.y).normalized;
        _controller.Move(direction * _speed * Time.deltaTime);
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, _minX, _maxX);
        position.z = Mathf.Clamp(position.z, _minZ, _maxZ);
        transform.position = position;
    }
}