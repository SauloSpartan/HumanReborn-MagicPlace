using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAnimator : MonoBehaviour
{
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        if (Input.GetMouseButtonDown(0))
        {
            _animator.Play("Attack");
            return;
        }

        if (moveX != 0)
        {
            _animator.Play("Walk");
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.Play("Jump");
        }
    }
}