using UnityEngine;

public class TPickItem : MonoBehaviour
{
    [SerializeField] private TInventoryManager _inventoryManager;
    [SerializeField] private ItemData[] _items;
    private SpriteRenderer _image;

    private void Awake()
    {
        _image = GetComponent<SpriteRenderer>();
        _image.sprite = _items[2].ItemSprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _inventoryManager.AddItem(_items[2]);
    }
}
