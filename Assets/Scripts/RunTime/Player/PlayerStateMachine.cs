using UnityEngine;

// This is the main state machine, controls the logic and has the main variables and functions
public class PlayerStateMachine : MonoBehaviour
{
    // Movement variables
    private Rigidbody2D _rigidBody;
    [SerializeField] private float _speed = 5;
    private float _moveX;

    // Animation variables
    private Animator _animator;

    // State variables
    private PlayerBaseState _currentState;
    private PlayerStateFactory _states;

    // Getters and Setters
    /// <value> Reference to BaseState Script. </value>
    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public float MoveX { get { return _moveX; } set { _moveX = value; } }
    public Animator Animator { get { return _animator; } set { _animator = value; } }

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
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
    }

    public void Movement()
    {
        _rigidBody.velocity = new Vector2(_moveX * _speed, _rigidBody.velocity.y);
    }
}
