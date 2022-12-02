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
        AnimatorStateInfo currInfo = _animator.GetCurrentAnimatorStateInfo(0);
        float lenght = currInfo.length;
        Debug.Log(lenght);
    }

    private void Move()
    {
        // Gets button pressed
        float moveX = Input.GetAxis("Horizontal");
        _rigidBody.velocity = new Vector2(moveX * _speed, _rigidBody.velocity.y);

        //Change animation
        if (IsGrounded() == true)
        {
            if (moveX != 0)
            {
                _animator.Play("Walk");
            }
            else
            {
                _animator.Play("Idle");
            }
        }

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
        }

        if ((Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true) || IsGrounded() == false)
        {
            _animator.Play("Jump_1");
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
        // With state machine
        if (Input.GetMouseButtonDown(0))
        {
            //_animator.Play("Attack_Melee_Sword");
        }
    }

    private void OnDrawGizmos()
    {
        float distToGround = _boxCollider.bounds.extents.y;
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector2.down * (distToGround + 0.3f));
    }
}
