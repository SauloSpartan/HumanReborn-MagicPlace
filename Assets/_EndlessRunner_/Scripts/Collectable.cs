using UnityEngine;

public enum CollectableType
{
    healthPotion,
    manaPotion,
    coin
}

public class Collectable : MonoBehaviour
{
    public CollectableType Type;
    private SpriteRenderer _sprite;
    private CircleCollider2D _itemCollider;
    private bool _wasCollected;
    public int Value;

    void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _itemCollider = GetComponent<CircleCollider2D>();
        _wasCollected = false;
    }

    private void ShowItem()
    {
        _sprite.enabled = true;
        _itemCollider.enabled = true;
        _wasCollected = false;
    }

    private void HideItem()
    {
        _sprite.enabled = false;
        _itemCollider.enabled = false;
    }

    private void CollectItem()
    {
        HideItem();
        _wasCollected = true;

        switch (Type)
        {
            case CollectableType.healthPotion:
                PlayerController.Instance.CollectHealth(Value);
                break;
            case CollectableType.manaPotion:
                PlayerController.Instance.CollectMana(Value);
                break;
            case CollectableType.coin:
                GameManager.Instance.CollectObject(this);
                GetComponent<AudioSource>().Play();
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CollectItem();
        }
    }
}
