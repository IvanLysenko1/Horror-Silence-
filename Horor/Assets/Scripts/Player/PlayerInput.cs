using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 GetMovementInput()
    {
        float horizontal = Input.GetAxis(GlobalStringVars.Horizontal);
        float vertical = Input.GetAxis(GlobalStringVars.Vertical);
        return new Vector2(horizontal, vertical);
    }

    public bool GetJumpInput()
    {
        return Input.GetButtonDown(GlobalStringVars.Jump);
    }

    public Vector2 GetMouseInput()
    {
        float mouseX = Input.GetAxis(GlobalStringVars.MouseX);
        float mouseY = Input.GetAxis(GlobalStringVars.MouseY);
        return new Vector2(mouseX, mouseY);
    }

    public bool GetFlashlightToggleInput()
    {
        return Input.GetButtonUp(GlobalStringVars.FlashlightToggle);
    }
}
