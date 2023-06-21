using UnityEngine;

public class TJump : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    [SerializeField] private float _jumpForce;
    [SerializeField] private int _maxJumps;
    private int _initialJumps;
    private LayerMask _groundLayer;
    [SerializeField] private float _timer;
    private float _initialTime;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _initialJumps = _maxJumps;
        _groundLayer = LayerMask.GetMask("Ground");
        _initialTime = _timer;
    }

    void Update()
    {
        if (_maxJumps > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 0);
            _rigidBody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _maxJumps -= 1;
        }

        if (_timer <= 0 && IsGrounded())
        {
            _maxJumps = _initialJumps;
            _timer = _initialTime;
        }

        if (!IsGrounded())
        {
            _timer -= Time.deltaTime;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(transform.position, 0.2f, _groundLayer);
    }
}
