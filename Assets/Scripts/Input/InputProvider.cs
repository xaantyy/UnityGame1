using UnityEngine;
using UnityEngine.InputSystem;

public class InputProvider : MonoBehaviour
{
    public Vector2 GetMoveDirection()
    {
        Vector2 direction = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
            direction.y = 1;

        if (Keyboard.current.sKey.isPressed)
            direction.y = -1;

        if (Keyboard.current.aKey.isPressed)
            direction.x = -1;

        if (Keyboard.current.dKey.isPressed)
            direction.x = 1;

        if(Gamepad.current != null)
        {
            direction = Gamepad.current.leftStick.ReadValue();
        }
        
        return direction;
    }
}