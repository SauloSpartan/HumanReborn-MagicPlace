using UnityEngine;
using TMPro;

public class TestTalkingSystem_2 : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private SpriteRenderer _spriteButton;
    [SerializeField] private float _talkingDistance;
    private BoxCollider2D _boxCollider;
    private BoxCollider2D _playerCollider;
    private TMP_Text _text;
    private bool _isTalking;

    void Awake()
    {
        _spriteButton.enabled = false;
        _boxCollider = GetComponent<BoxCollider2D>();
        _playerCollider = _player.GetComponent<BoxCollider2D>();
        _text = GetComponentInChildren<TMP_Text>();
        _text.enabled = false;

        Physics2D.IgnoreCollision(_boxCollider, _playerCollider);
    }

    void Update()
    {
        float distance = Vector2.Distance(_player.position, transform.position);
        if (_isTalking == false)
        {
            if (distance < _talkingDistance)
            {
                _spriteButton.enabled = true;

                if (Input.GetKeyDown(KeyCode.W))
                {
                    _isTalking = true;
                }
            }
            else
            {
                _spriteButton.enabled = false;
            }
        }
        else if (_isTalking == true)
        {
            _spriteButton.enabled = false;

            if (distance < _talkingDistance)
            {
                _text.enabled = true;
            }
            else
            {
                _text.enabled = false;
                _isTalking = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _talkingDistance);
    }
}