using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TestWander : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private Vector2 _origin;
    private Animator _animator;
    private SpriteRenderer _sprite;
    [SerializeField] private float _wanderDistance;
    [SerializeField] private float _speed = 3;
    [SerializeField] private float _direction = 1;

    void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _origin = transform.position;
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine(WanderAround());
    }

    void Update()
    {
        _rigidBody.velocity = new Vector2(_direction * _speed, _rigidBody.velocity.y);

        if (_direction != 0)
        {
            _animator.Play("Walk");
        }
        else
        {
            _animator.Play("Idle");
        }

        if (_direction < 0)
        {
            _sprite.flipX = true;
        }
        else if (_direction > 0)
        {
            _sprite.flipX = false;
        }

        //float distance = Mathf.Abs((transform.position.x - _origin.x));
    }

    private IEnumerator WanderAround()
    {
        while (true) 
        {
            int randomDirection = Random.Range(-1, 2);

            _direction = randomDirection;

            yield return new WaitForSecondsRealtime(2f);
        }
    }
}
