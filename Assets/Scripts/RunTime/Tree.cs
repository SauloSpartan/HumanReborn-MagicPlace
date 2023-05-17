using System.Collections;
using TMPro;
using UnityEngine;

public class Tree : MonoBehaviour, IDamagable
{
    [SerializeField] private GameObject _wood;
    [SerializeField] private int _woodAmount;
    private Vector2 _initialPosition;
    [SerializeField] private int _health;

    void Start()
    {
        _initialPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hand")
        {
            _health--;
            StartCoroutine(TreeShake(0.1f, 1f));
            Damage();
        }
    }

    public void Damage()
    {
        if (_health <= 0)
        {
            for (int i = 0; i < _woodAmount; i++)
            {
                Instantiate(_wood, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    private IEnumerator TreeShake(float duration, float magnitude)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            Vector3 newPosition = _initialPosition;
            float x_Position = Random.Range(-0.1f, 0.1f) * magnitude;

            transform.position = new Vector2(newPosition.x + x_Position, _initialPosition.y);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = _initialPosition;
    }
}
