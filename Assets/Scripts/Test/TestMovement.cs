using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    [SerializeField] private HumanoidData _humanoidData;
    private Rigidbody _rigidBody;
    private float _speed = 20;
    private Animator _animator;
    [SerializeField] private BoxCollider _boxCollider;
    private TestRenderer[] _testRenderer;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider>();
        _testRenderer = GetComponentsInChildren<TestRenderer>();
    }

    void Update()
    {
        Move();
        Jump();
        Melee();
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");

        Vector3 inputMovement = new Vector2(moveX, 0);

        inputMovement = transform.up * inputMovement.x;
        _rigidBody.MovePosition(transform.position + inputMovement * _speed * Time.deltaTime);

        if (inputMovement.x < 0)
        {
            _testRenderer[0].TestFlipMaterial(-1, 1.06f);
            _testRenderer[1].TestFlipMaterial(-1, 1.06f);
        }
        else if (inputMovement.x > 0)
        {
            _testRenderer[0].TestFlipMaterial(1, 0);
            _testRenderer[1].TestFlipMaterial(1, 0);
        }

        if (inputMovement != Vector3.zero)
        {
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }

    private void Jump()
    {
        float force = 5;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            _rigidBody.AddForce(Vector2.up * force, ForceMode.Impulse);
        }

        if (IsGrounded() == false)
        {
            _animator.SetBool("isJumping", true);
        }
        else if (IsGrounded() == true)
        {
            _animator.SetBool("isJumping", false);
        }
    }

    private bool IsGrounded()
    {
        LayerMask _groundLayer = LayerMask.GetMask("Ground");
        float distToGround = _boxCollider.bounds.extents.y;
        return Physics.Raycast(transform.position, Vector2.down, distToGround - 0.5f, _groundLayer);
    }

    private void Melee()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("Melee1R");
        }
    }

    private void OnDrawGizmos()
    {
        float distToGround = _boxCollider.bounds.extents.y;
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector2.down * (distToGround - 0.5f));
    }
}