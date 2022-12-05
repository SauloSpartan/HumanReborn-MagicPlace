using UnityEngine;

public class TestTalkingSystem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private SpriteRenderer _faceSprite;
    private bool _isActive;

    void Awake()
    {
        _sprite.enabled = false;
        _faceSprite.enabled = false;
        _isActive = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _isActive = false;
            _faceSprite.enabled = true;
        }

        if (_isActive == false)
        {
            _sprite.enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && _isActive == true)
        {
            _sprite.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _sprite.enabled = false;
            _faceSprite.enabled = false;
            _isActive = true;
        }
    }
}