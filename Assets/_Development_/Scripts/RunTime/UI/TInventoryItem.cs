using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

// On "InventoryItem", manages the visuals and code for items on inventory with Unity Interfaces.
public class TInventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _countText;
    public ItemData Item;
    [HideInInspector] public Transform InitialParent;
    [HideInInspector] public int Count = 1;

    void Awake()
    {
        _image = GetComponent<Image>();
        _countText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void InitialiseItem(ItemData newItem)
    {
        Item = newItem;
        _image.sprite = newItem.ItemSprite;
        RefreshCount(Item.IsStackable);
    }

    /// <summary>
    /// Refresh the item stack count if is stackable.
    /// </summary>
    /// <param name="stackable"> Receives a bool if stackable.</param>
    public void RefreshCount(bool stackable)
    {
        bool isStackable = stackable ? _countText.enabled = true : _countText.enabled = false; // Ternary Conditional Operator

        _countText.text = Count.ToString(); // Refresh the count and converts it to string.
    }

    /// <summary>
    /// Interface implementation of Unity begin drag handler.
    /// </summary>
    /// <param name="eventData"> Receives a PointerEventData parameter.</param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        _image.raycastTarget = false;
        InitialParent = transform.parent;
        transform.SetParent(transform.root);
    }

    /// <summary>
    /// Interface implementation of Unity drag handler.
    /// </summary>
    /// <param name="eventData"> Receives a PointerEventData parameter.</param>
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    /// <summary>
    /// Interface implementation of Unity end drag handler.
    /// </summary>
    /// <param name="eventData"> Receives a PointerEventData parameter.</param>
    public void OnEndDrag(PointerEventData eventData)
    {
        _image.raycastTarget = true;
        transform.SetParent(InitialParent);
    }
}
