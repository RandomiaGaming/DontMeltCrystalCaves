using UnityEngine;
public static class InputHelper
{
    public const float JoystickDeadZone = 0.2f;
    public static bool IsJumpDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            return true;
        }
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x > Screen.width / 2)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public static bool IsSwitchDirectionDown()
    {
        if (Input.GetMouseButtonDown(1))
        {
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            return true;
        }
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x <= Screen.width / 2)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public static bool IsRightDown()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return true;
        }
        else if (Input.GetAxisRaw("JoystickXAxis") > JoystickDeadZone)
        {
            return true;
        }
        return false;
    }
    public static bool IsLeftDown()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return true;
        }
        else if (Input.GetAxisRaw("JoystickXAxis") < JoystickDeadZone * -1)
        {
            return true;
        }
        return false;
    }
}
