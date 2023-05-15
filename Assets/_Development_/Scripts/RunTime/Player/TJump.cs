using System.Collections;
using UnityEngine;

public class TJump : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    [SerializeField] private float _jumpForce;
    [SerializeField] private int _maxJumps;
    [SerializeField] private float _groundDistance;
    [SerializeField] private LayerMask _groundLayer;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _maxJumps > 0)
        {
            _rigidBody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _maxJumps -= 1;
        }
    }
}
