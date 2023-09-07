using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Vector2 _dir; 
    private CircleCollider2D _collider;
    public float PlayerRadius => _collider.radius;

    private Vector2 _vel;

    private bool _canMove = true;

    public void MovePlayer()
    {
        _vel += new Vector2(_dir.x, _dir.y) * _speed;
        _rb.MovePosition(_vel * Time.fixedDeltaTime);
    }

    private void Start() => _collider = GetComponent<CircleCollider2D>() ?? transform.AddComponent<CircleCollider2D>();

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (_canMove)
        {
            MovePlayer();
        }
    }
    
    public void GetDirectionMovement(InputAction.CallbackContext p_ctx)
    {
        Vector2 l_direction = p_ctx.ReadValue<Vector2>();
        _dir = l_direction;
    }

    public void CancelDirectionMovement(InputAction.CallbackContext p_ctx)
    {
        _dir = Vector2.zero;
    }
}
