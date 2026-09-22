using UnityEngine;

public class InputService
{
    private InputProvider _inputProvider;

    public InputService(InputProvider inputProvider)
    {
        _inputProvider = inputProvider;
    }

    public Vector2 GetMoveDirection()
    {
        return _inputProvider.GetMoveDirection();
    }
}