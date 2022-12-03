using UnityEngine;

public class TMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    [SerializeField] private float _speed = 5;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        _rigidBody.velocity = new Vector2(moveX * _speed, _rigidBody.velocity.y);
    }
}
