using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByJoystick : MonoBehaviour
{
    [SerializeField]
    private Transform _cameraHolder;

    [SerializeField]
    private JoyStick _joyStick;

    [SerializeField]
    private float _sensitivity = 0.1f;

    [SerializeField]
    private float _minPitch = -45.0f;
    [SerializeField]
    private float _maxPitch = 30.0f;

    private bool allowRotation;

    private void Start()
    {
        // Khoi dong cham de tranh vi tri chuot ban dau
        Invoke(nameof(EnableRotation), 1f);
    }

    private void EnableRotation() => allowRotation = true;

    private void Update()
    {

        if (!allowRotation) return;
        UpdateYaw();
        UpdatePitch();
    }

    private void UpdateYaw()
    {
        float joystickDx = _joyStick.Input.x;
        transform.Rotate(0, joystickDx * _sensitivity, 0);
    }

    private void UpdatePitch()
    {
        float joystickDy = _joyStick.Input.y;
        _cameraHolder.Rotate(-joystickDy * _sensitivity, 0, 0);
        ClampPitchAngle();
    }

    private void ClampPitchAngle()
    {
        float pitch = _cameraHolder.localEulerAngles.x;
        if (pitch > 180)
        {
            pitch -= 360;
        }
        if (pitch < -180)
        {
            pitch += 360;
        }
        pitch = Mathf.Clamp(pitch, _minPitch, _maxPitch);
        _cameraHolder.localEulerAngles = new Vector3(pitch, 0, 0);
    }
}
