using UnityEngine;

public class AimController : MonoBehaviour
{
    public Transform aimPivot;
    public JoystickController aimJoystick;

    void Update()
    {
        Vector2 aimDir = aimJoystick.Direction;

        if (aimDir.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
            aimPivot.rotation = Quaternion.Euler(0, 0, angle - 90f);
        }
    }
}