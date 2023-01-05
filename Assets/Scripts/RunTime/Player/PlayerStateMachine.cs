using UnityEngine;

// This is the main state machine, controls the logic and has the main variables and functions
public class PlayerStateMachine : MonoBehaviour
{
    // Movement variables
    private Rigidbody2D _rigidBody;
    [SerializeField] private BoxCollider2D _boxCollider;
    [SerializeField] private float _speed = 5;
    private float _moveInX;

    // Jump variables
    private bool _jumpKey;
    [SerializeField] private float _jumpForce = 2;
    [SerializeField] private float _groundDistance;

    // Animation variables
    private Animator _animator;
    private SpriteRenderer _sprite;

    // State variables
    private PlayerBaseState _currentState;
    private PlayerStateFactory _states;

    // Getters and Setters
    /// <value> Reference to BaseState Script. </value>
    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public Rigidbody2D RigidBody { get { return _rigidBody; } set { _rigidBody = value; }}
    public float Speed { get { return _speed; } } 
    public float MoveInX { get { return _moveInX; } set { _moveInX = value; } }
    public bool JumpKey { get { return _jumpKey; } set { _jumpKey = value; } }
    public float JumpForce { get { return _jumpForce; } }
    public Animator Animator { get { return _animator; } set { _animator = value; } }

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        // Setup state
        _states = new PlayerStateFactory(this); // "(this)" is a PlayerStateMachine instance
        _currentState = _states.Idle();
        _currentState.EnterState();
    }

    void Update()
    {
        // Setup state
        _currentState.UpdateState();

        // Other functions
        GetInputs();
    }

    /// <summary>
    /// Get the inputs of any key needed.
    /// </summary>
    private void GetInputs() 
    {
        // Movement in X inputs
        _moveInX = Input.GetAxis("Horizontal");
        if (_moveInX < 0)
        {
            _sprite.flipX = true;
        }
        else if (_moveInX > 0)
        {
            _sprite.flipX = false;
        }

        //Jump inputs
        _jumpKey = Input.GetKeyDown(KeyCode.Space);
    }

    public bool IsGrounded()
    {
        LayerMask _groundLayer = LayerMask.GetMask("Ground");
        float distanceToGround = _boxCollider.bounds.extents.y;
        return Physics2D.Raycast(transform.position, Vector2.down, distanceToGround + _groundDistance, _groundLayer);
    }

    private void OnDrawGizmos()
    {
        float distanceToGround = _boxCollider.bounds.extents.y;
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector2.down * (distanceToGround + _groundDistance));
    }
}
