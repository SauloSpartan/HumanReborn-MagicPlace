using UnityEngine;

public class TFlipSprite : MonoBehaviour
{
    private SpriteRenderer _sprite;

    void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        if (moveX < 0)
        {
            _sprite.flipX = true;
        }
        else if (moveX > 0)
        {
            _sprite.flipX = false;
        }
    }
}
