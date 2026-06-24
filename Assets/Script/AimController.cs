using UnityEngine;

public class AimController : MonoBehaviour
{
    public JoystickController aimJoystick;   // RIGHT joystick
    public float smooth = 20f;

    void Update()
    {
        Vector2 input = aimJoystick.Direction;

        if (input.magnitude < 0.2f)
            return;

        float angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(0, 0, angle),
            smooth * Time.deltaTime
        );
    }
}