using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByJoyStick : MonoBehaviour
{
    [HideInInspector]
    [SerializeField]
    private CharacterController _characterController;
    [SerializeField]
    private JoyStick _joyStick;
    [SerializeField]
    private float _speed = 7;
    [SerializeField]
    private AudioSource _footstepSound;
    private bool _isMoving = false;
    private float _minMoveDistance = 1e-2f;

    [SerializeField]
    private float _jumpHeight = 2f;
    private float _groundDistance = 1.12f;
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
        UpdateMoving();
        UpdateJumping();
    }

    private void LimitVelocityY()
    {
        _velocity.y += _gravity * Time.deltaTime;
        if (_velocity.y < -2)
        {
            _velocity.y = -2;
        }
    }

    private void UpdateMoving()
    {
        Vector2 input = new Vector2(_joyStick.Input.x, _joyStick.Input.y);
        Move(input);
        PlayMovingSound(input);
        UpdateMovingState(input);
    }
    private void Move(Vector2 input)
    {
        Vector3 direction = transform.forward * input.y + transform.right * input.x;
        _characterController.Move(direction * _speed * Time.deltaTime);
    }

    private void PlayMovingSound(Vector2 input)
    {
        if (input.magnitude > _minMoveDistance && _isMoving == false)
        {
            _footstepSound.Play();
        }
        else if (input.magnitude <= _minMoveDistance)
        {
            _footstepSound.Pause();
        }
    }

    private void UpdateMovingState(Vector2 input)
    {
        _isMoving = (input.magnitude > _minMoveDistance);
    }

    private void UpdateJumping()
    {
        _characterController.Move(_velocity * Time.deltaTime);
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
