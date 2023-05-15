using UnityEngine;

public class TJump : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    [SerializeField] private float _jumpForce;
    [SerializeField] private int _maxJumps;
    private int _initialJumps;
    private LayerMask _groundLayer;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _initialJumps = _maxJumps;
        _groundLayer = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _maxJumps > 0)
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 0);
            _rigidBody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _maxJumps -= 1;
        }

        if (IsGrounded())
        {
            _maxJumps = _initialJumps;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(transform.position, 0.2f, _groundLayer);
    }
}
