using UnityEngine;

public class TPickItem : MonoBehaviour
{
    [SerializeField] private TInventoryManager _inventoryManager;
    [SerializeField] private ItemData[] _items;
    [SerializeField] private int _itemID;
    private SpriteRenderer _image;

    private void Awake()
    {
        _image = GetComponent<SpriteRenderer>();
        _image.sprite = _items[_itemID].ItemSprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _inventoryManager.AddItem(_items[_itemID]);
            Destroy(gameObject);
        }
    }
}
