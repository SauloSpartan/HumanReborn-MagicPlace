using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TJump2 : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;
    private LayerMask _groundLayer = LayerMask.GetMask("Ground");
    private float _distanceX;
    private float _distanceY;

    void Awake()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
        _boxCollider = gameObject.GetComponent<BoxCollider2D>();
        _distanceX = _boxCollider.bounds.extents.x;
        _distanceY = _boxCollider.bounds.extents.y;
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && IsTouchingGround() && IsGrounded())
        {
            _rigidBody.AddForce(Vector2.up * 100f, ForceMode2D.Force);
        }
    }

    private bool IsTouchingGround() => _rigidBody.IsTouchingLayers(_groundLayer);
    private bool IsGrounded() => Physics2D.BoxCast(_boxCollider.bounds.center, new Vector2(_distanceX, _distanceY), 0f, Vector2.down, -0.1f, _groundLayer);
}