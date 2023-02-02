using UnityEngine;

public class TestEnemySystem : MonoBehaviour
{
    public float XpAmount;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Destroy(gameObject);
    }
}
