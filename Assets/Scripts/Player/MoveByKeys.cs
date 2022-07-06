using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MoveByKeys : MonoBehaviour
{
    [HideInInspector]
    [SerializeField]
    private CharacterController _characterController;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _jumpHeight;

    [SerializeField]
    private float _groundDistance;

    [SerializeField]
    private AudioSource _footstepSound;
    private bool _isMoving = false;

    private Vector3 _velocity;
    private float _gravity = -9.81f;

    void OnValidate()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        LimitVelocityY();
        UpdateMoving();
        UpdateJumping();
        PlayMovingSound();
    }

    private void LimitVelocityY()
    {
        if (_velocity.y < -2)
        {
            _velocity.y = -2;
        }
    }
    private void UpdateMoving()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        Vector3 direction = transform.forward * vInput + transform.right * hInput;
        _characterController.Move(direction * _speed * Time.deltaTime);
    }

    private void UpdateJumping()
    {
        _velocity.y += _gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                // v0 = sqrt(2gh)
                _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
            }
        }
    }
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, _groundDistance);
    }

    private void PlayMovingSound()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        if(hInput != 0 || vInput != 0)
        {
            if (!_isMoving)
            {
                _isMoving = true;
                _footstepSound.Play();
            }
        }
        else
        {
            _isMoving = false;
            _footstepSound.Pause();
        }
    }
}
