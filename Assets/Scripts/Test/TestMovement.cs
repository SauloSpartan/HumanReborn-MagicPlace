using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private float _speed = 20;
    private Animator _animator;
    [SerializeField] private HumanoidData _humanoidData;
    private TestRenderer[] _testRenderer;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _testRenderer = GetComponentsInChildren<TestRenderer>();
    }

    void Update()
    {
        Move();
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
}
