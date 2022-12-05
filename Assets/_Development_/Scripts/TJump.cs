using UnityEngine;

public class TJump : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    [SerializeField] float _force;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 0);
            _rigidBody.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
        }
    }
}
