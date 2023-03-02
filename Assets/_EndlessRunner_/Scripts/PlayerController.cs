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

    private int _healthPoints;
    private int _manaPoints;
    public const int Initial_Health = 100;
    public const int Initial_Mana = 100;
    public const int Max_Health = 200;
    public const int Max_Mana = 200;
    public const int Min_Health = 0;
    public const int Min_Mana = 0;

    public const int SuperJump_Cost = 5;
    public const float SuperJump_Force = 1.5f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _startPosition = new Vector2(0, 0);
        _rigidbody2D.isKinematic = true;
        _animator.enabled = false;
    }

    void Update()
    {
        if (GameManager.Instance.CurrentState != GameState.inGame)
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.isKinematic = true;
            return;
        }

        if (GameManager.Instance.CurrentState == GameState.menu)
        {
            _animator.enabled = false;
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
        _animator.enabled = true;

        _healthPoints = Initial_Health;
        _manaPoints = Initial_Mana;

        GameObject mainCamera = GameObject.Find("Main Camera");
        mainCamera.GetComponent<CameraFollow>().ResetCameraPosition();
    }

    private void Jump()
    {
        float jumpForceFactor = _jumForce;

        if ((Input.GetButtonDown("Jump")) && IsGrounded())
        {
            _rigidbody2D.AddForce(Vector2.up * _jumForce, ForceMode2D.Impulse);
            GetComponent<AudioSource>().Play();
        }

        /*if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && IsGrounded())
        {
            _rigidbody2D.AddForce(Vector2.up * _jumForce, ForceMode2D.Impulse);
        }*/

        if (Input.GetMouseButtonDown(1) && IsGrounded())
        {
            if (_manaPoints >= SuperJump_Cost)
            {
                _manaPoints -= SuperJump_Cost;
                jumpForceFactor *= SuperJump_Force;
                _rigidbody2D.AddForce(Vector2.up * jumpForceFactor, ForceMode2D.Impulse);
                GetComponent<AudioSource>().Play();
            }
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

    public void Death()
    {
        float travelledDistance = GetTravelledDistance();
        float prevoiusMaxDistance = PlayerPrefs.GetFloat("maxscore", 0f);
        if (travelledDistance > prevoiusMaxDistance)
        {
            PlayerPrefs.SetFloat("maxscore", travelledDistance);
        }

        _animator.SetBool(State_Alive, false);
        GameManager.Instance.GameOver();
    }

    public void CollectHealth(int points)
    {
        _healthPoints += points;
        if (_healthPoints >= Max_Health)
        {
            _healthPoints = Max_Health;
        }

        if (_healthPoints <= 0)
        {
            Death();
        }
    }
    
    public void CollectMana(int points)
    {
        _manaPoints += points;
        if (_manaPoints >= Max_Mana)
        {
            _manaPoints = Max_Mana;
        }
    }

    public int GetHealth()
    {
        return _healthPoints;
    }

    public int GetMana()
    {
        return _manaPoints;
    }

    public float GetTravelledDistance()
    {
        return transform.position.x - _startPosition.x;
    }
        
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * _raycastDistance);
    }
}