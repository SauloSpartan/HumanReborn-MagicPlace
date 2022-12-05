using UnityEngine;

public class TJump : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    [SerializeField] float _force;
    [SerializeField] private BoxCollider2D _boxCollider;
    [SerializeField] private int _maxJumps;
    private int _remainJumps;
    [SerializeField] private float _groundDistance;
    private float _distanceX;
    private float _distanceY;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _remainJumps = _maxJumps;
        _distanceX = _boxCollider.bounds.extents.x;
        _distanceY = _boxCollider.bounds.extents.y;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _remainJumps > 0)
        {
            _remainJumps--;
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 0);
            _rigidBody.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
        }

        if (IsGrounded())
        {
            _remainJumps = _maxJumps;
        }
    }

    private bool IsGrounded()
    {
        LayerMask _groundLayer = LayerMask.GetMask("Ground");
        return Physics2D.BoxCast(_boxCollider.bounds.center, new Vector2(_distanceX, _distanceY), 0f, Vector2.down, _groundDistance, _groundLayer);
    }
}
