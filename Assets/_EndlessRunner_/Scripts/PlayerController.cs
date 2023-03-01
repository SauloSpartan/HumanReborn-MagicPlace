using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _jumForce;
    [SerializeField] private float _raycastDistance;
    [SerializeField] private LayerMask _groundMask;
    private Vector2 _startPosition;

    private Animator _animator;
    private const string State_Alive = "isAlive";
    private const string State_Grounded = "isGrounded";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _startPosition = new Vector2(0, 0);
    }

    void Update()
    {
        if (GameManager.Instance.CurrentState != GameState.inGame)
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.isKinematic = true;
            return;
        }

        _rigidbody2D.isKinematic = false;
        Jump();
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.CurrentState != GameState.inGame)
        {

            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
            return;
        }

        if (_rigidbody2D.velocity.x < _walkSpeed)
        {
            _rigidbody2D.velocity = new Vector2(_walkSpeed, _rigidbody2D.velocity.y);
        }
    }

    public void StartGame()
    {
        _animator.SetBool(State_Alive, true);
        _animator.SetBool(State_Grounded, true);
        transform.position = _startPosition;

        GameObject mainCamera = GameObject.Find("Main Camera");
        mainCamera.GetComponent<CameraFollow>().ResetCameraPosition();
    }

    private void Jump()
    {
        if ((Input.GetButtonDown("Jump")) && IsGrounded())
        {
            _rigidbody2D.AddForce(Vector2.up * _jumForce, ForceMode2D.Impulse);
        }

        /*if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && IsGrounded())
        {
            _rigidbody2D.AddForce(Vector2.up * _jumForce, ForceMode2D.Impulse);
        }*/

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

    public void Death()
    {
        _animator.SetBool(State_Alive, false);
        GameManager.Instance.GameOver();
    }
        
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * _raycastDistance);
    }
}