using UnityEngine;

public class ExitZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            LevelManager.Instance.AddLevelBlock();
            LevelManager.Instance.RemoveLevelBlock();
        }
    }
}
