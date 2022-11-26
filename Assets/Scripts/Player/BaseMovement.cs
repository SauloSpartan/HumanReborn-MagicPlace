using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private float _speed = 20;
    private Animator _animator;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");

        Vector3 inputMovement = new Vector3(moveX, 0, 0);

        inputMovement = transform.up * inputMovement.x;
        _rigidBody.MovePosition(transform.position + inputMovement * _speed * Time.deltaTime);

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
