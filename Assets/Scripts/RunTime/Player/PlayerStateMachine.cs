using UnityEngine;

// This is the main state machine, controls the logic and has the main variables and functions
public class PlayerStateMachine : MonoBehaviour
{
    // Movement variables
    private Rigidbody2D _rigidBody;
    [SerializeField] private float _speed = 5;
    private float _moveInX;

    // Jump variables
    private bool _jumpKey;
    [SerializeField] private float _jumpForce = 2;
    [SerializeField] private int _maxJumps;
    private int _initialJumps;

    // Attack variables
    private bool _clickButton;

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
    public int MaxJumps { get { return _maxJumps; }  set { _maxJumps = value; } }
    public int InitialJumps { get { return _initialJumps; } }
    public bool ClickButton { get { return _clickButton; } }
    public Animator Animator { get { return _animator; } set { _animator = value; } }

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();

        _initialJumps = _maxJumps;
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

        //Click inputs
        _clickButton = Input.GetMouseButton(0);
    }

    public bool IsGrounded()
    {
        LayerMask _groundLayer = LayerMask.GetMask("Ground");
        return Physics2D.OverlapCircle(transform.position, 0.2f, _groundLayer);
    }
}
