using UnityEngine;

public class TestOrbSystem : MonoBehaviour
{
    public float XpAmount = 0;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Destroy(gameObject);
    }
}
