using UnityEngine;

public class TJump : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float force = 5;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }
}
