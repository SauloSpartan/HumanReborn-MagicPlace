using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement2 : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    [SerializeField] private float _speed = 20;
    [SerializeField] private BoxCollider2D _boxCollider;
    private SpriteRenderer _renderer;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");

        _rigidBody.velocity = new Vector2(moveX * _speed, _rigidBody.velocity.y);

        if (moveX < 0)
        {
            _renderer.flipX = true;
        }
        else if (moveX > 0)
        {
            _renderer.flipX = false;
        }
    }

    private void Jump()
    {
        float force = 5;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            _rigidBody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        LayerMask _groundLayer = LayerMask.GetMask("Ground");
        float distToGround = _boxCollider.bounds.extents.y;
        return Physics2D.Raycast(transform.position, Vector2.down, distToGround + 0.3f, _groundLayer);
    }

    private void OnDrawGizmos()
    {
        float distToGround = _boxCollider.bounds.extents.y;
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector2.down * (distToGround + 0.3f));
    }
}
