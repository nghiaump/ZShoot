using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    [HideInInspector]
    [SerializeField]
    private CharacterController _characterController;

    [SerializeField]
    private float _jumpHeight;

    [SerializeField]
    private float _groundDistance;

    private Vector3 _velocity;
    private float _gravity = -9.81f;
    private float _lastJumpTime = 0;
    private float _interval = 2f;

    void OnValidate()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        LimitVelocityY();
        UpdateJumping();
    }

    private void LimitVelocityY()
    {
        if (_velocity.y < -2)
        {
            _velocity.y = -2;
        }
    }

    private void UpdateJumping()
    {
        _velocity.y += _gravity * Time.deltaTime;
        //_characterController.Move(_velocity * Time.deltaTime);
        if (ButtonToKeyConverter.s_buttonJumpDown && Time.time - _lastJumpTime > _interval)
        {
            if (IsGrounded())
            {
                // v0 = sqrt(2gh)
                _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
                _lastJumpTime = Time.time;
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, _groundDistance);
    }
}
