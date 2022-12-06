using UnityEngine;

public class TestTalkingSystem_2 : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private SpriteRenderer _spriteButton;
    [SerializeField] private float _talkingDistance;
    private BoxCollider2D _boxCollider;
    private BoxCollider2D _playerCollider;

    void Awake()
    {
        _spriteButton.enabled = false;
        _boxCollider = GetComponent<BoxCollider2D>();
        _playerCollider = _player.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(_boxCollider, _playerCollider);
    }

    void Update()
    {
        float distance = Vector2.Distance(_player.position, transform.position);
        if (distance < _talkingDistance) 
        {
            _spriteButton.enabled = true;
        }
        else
        {
            _spriteButton.enabled = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _talkingDistance);
    }
}