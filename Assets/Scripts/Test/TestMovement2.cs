using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement2 : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    [SerializeField] private float _speed = 20;
    [SerializeField] private BoxCollider2D _boxCollider;
    private SpriteRenderer _renderer;
    private Animator _animator;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
        MeleeSword();
    }

    private void Move()
    {
        // Gets button pressed
        float moveX = Input.GetAxis("Horizontal");
        _rigidBody.velocity = new Vector2(moveX * _speed, _rigidBody.velocity.y);

        // Activates animation
        bool isWalking = (moveX != 0) ? true : false;
        _animator.SetBool("isWalking", isWalking);

        // Flips sprite
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
            _animator.SetBool("isJumping", true);
        }
        else if (IsGrounded() == false)
        {
            _animator.SetBool("isJumping", true);
        }
        else
        {
            _animator.SetBool("isJumping", false);
        }
    }

    private bool IsGrounded()
    {
        LayerMask _groundLayer = LayerMask.GetMask("Ground");
        float distToGround = _boxCollider.bounds.extents.y;
        return Physics2D.Raycast(transform.position, Vector2.down, distToGround + 0.3f, _groundLayer);
    }

    private void MeleeSword()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("onSword");
        }
    }

    private void OnDrawGizmos()
    {
        float distToGround = _boxCollider.bounds.extents.y;
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector2.down * (distToGround + 0.3f));
    }
}
