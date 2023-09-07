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
    [SerializeField] private MinigameBaseData _minigameBaseData;
    [SerializeField] private Rigidbody2D _rb;

    private bool _isKill = false;

    public bool isKill => _isKill;

    private Vector2 _dir; 
    private CircleCollider2D _collider;
    public float PlayerRadius => _collider.radius;

    private Vector2 _vel;

    private bool _canMove = true;
    public void SetMiniGameData(MinigameBaseData data) => _minigameBaseData = data;
    public void MovePlayer()
    {
        _vel += new Vector2(_dir.x, _dir.y) * _minigameBaseData.PlayerSpeed;
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

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Enemy")
        {
            _isKill = true;
        }
    }
}
