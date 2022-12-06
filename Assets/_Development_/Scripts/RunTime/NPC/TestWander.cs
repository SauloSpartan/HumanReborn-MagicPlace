using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TestWander : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private Vector2 _origin;
    private Animator _animator;
    [SerializeField] private float _wanderDistance;
    [SerializeField] private float _speed = 3;
    [SerializeField] private float _direction = 1;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _origin = transform.position;
        _animator = GetComponent<Animator>();
        _animator.Play("Walk");
    }

    void Update()
    {
        _rigidBody.velocity = new Vector2(_direction * _speed, _rigidBody.velocity.y);

        //float distance = Mathf.Abs((transform.position.x - _origin.x));
    }
}
