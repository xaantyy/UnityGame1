using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private InputService _inputService;
    [Inject]
    public void Construct(InputService inputService)
    {
        _inputService = inputService;
    }
    public float speed = 28f;
    public float minX = -50f;
    public float maxX = 50f;
    public float minZ = -50f;
    public float maxZ = 50f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 input = _inputService.GetMoveDirection();
        Vector3 direction = new Vector3(input.x, 0f, input.y).normalized;
        controller.Move(direction * speed * Time.deltaTime);
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.z = Mathf.Clamp(position.z, minZ, maxZ);
        transform.position = position;
    }
}