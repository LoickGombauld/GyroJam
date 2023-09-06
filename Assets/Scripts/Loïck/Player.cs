using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Vector2 _dir;
    [SerializeField] private float _playerRadius;
    public float PlayerRadius => _playerRadius;

    private Vector2 _vel;
    private  Gyro _playerInput = new Gyro();
    private bool _canMove = true;

    private void Start()
    {
        _playerInput.Enable();
    }

    public void MovePlayer()
    {
        _vel += new Vector2(_dir.x, _dir.y) * _speed;
        _rb.MovePosition(_vel * Time.fixedDeltaTime);
    }


    private void Update()
    {
        if (_canMove)
        {
            MovePlayer();
        }
    }

    private void RegisterInputs()
    {
        Gyro.ControlsActions l_playerAction = _playerInput.Controls;
        l_playerAction.TrackBall.performed += GetDirectionMovement;
        l_playerAction.TrackBall.canceled += CancelDirectionMovement;
    }

    private void UnregisterInputs()
    {
        Gyro.ControlsActions l_playerAction = _playerInput.Controls;
        l_playerAction.TrackBall.performed -= GetDirectionMovement;
        l_playerAction.TrackBall.canceled -= CancelDirectionMovement;
    }

    private void OnEnable()
    {
        RegisterInputs();
    }

    private void OnDisable()
    {
        UnregisterInputs();
    }

    private void GetDirectionMovement(InputAction.CallbackContext p_ctx)
    {
        Vector2 l_direction = p_ctx.ReadValue<Vector2>();
        _dir = l_direction;
    }

    private void CancelDirectionMovement(InputAction.CallbackContext p_ctx)
    {
        _dir = Vector2.zero;
    }
}
