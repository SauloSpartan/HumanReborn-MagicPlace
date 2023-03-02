using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _flyingSpeed;
    private Rigidbody2D _rigidbody2D;
    public bool _facingRight;
    private Vector2 _startPosition;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
    }

    void Start()
    {
        transform.position = _startPosition;
    }

    void FixedUpdate()
    {
        float currentFlyingSpeed = _flyingSpeed;

        if (_facingRight) 
        {
            currentFlyingSpeed = _flyingSpeed;
            transform.eulerAngles = new Vector2(0, 180);
        }
        else
        {
            currentFlyingSpeed = -_flyingSpeed;
            transform.eulerAngles = Vector2.zero;
        }

        if (GameManager.Instance.CurrentState == GameState.inGame)
        {
            _rigidbody2D.velocity = new Vector2(currentFlyingSpeed, _rigidbody2D.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController.Instance.CollectHealth(-50);
            return;
        }

        _facingRight = !_facingRight;
    }
}
