using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _jumForce;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _raycastDistance;
    [SerializeField] private LayerMask _groundMask;

    private Animator _animator;
    private const string State_Alive = "isAlive";
    private const string State_Grounded = "isGrounded";

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        _animator.SetBool(State_Alive, true);
        _animator.SetBool(State_Grounded, true);
    }

    void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {
        if (_rigidbody2D.velocity.x < _movementSpeed)
        {
            _rigidbody2D.velocity = new Vector2(_movementSpeed, _rigidbody2D.velocity.y);
        }
    }

    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && IsGrounded())
        {
            _rigidbody2D.AddForce(Vector2.up * _jumForce, ForceMode2D.Impulse);
        }

        _animator.SetBool(State_Grounded, IsGrounded());
    }

    private bool IsGrounded() => Physics2D.Raycast(transform.position, Vector2.down, _raycastDistance, _groundMask);

    /*private bool IsGrounded()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, _raycastDistance, _groundMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }*/
        
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * _raycastDistance);
    }
}