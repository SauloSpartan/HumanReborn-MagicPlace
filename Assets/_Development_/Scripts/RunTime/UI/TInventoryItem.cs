using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

// On "InventoryItem", manages the visuals and code for items on inventory with Unity Interfaces.
public class TInventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Image _image;
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

    public void RefreshCount(bool stackable)
    {
        if (stackable == true)
        {
            _countText.enabled = true;
        }
        else
        {
            _countText.enabled = false;
        }

        _countText.text = Count.ToString();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _image.raycastTarget = false;
        InitialParent = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _image.raycastTarget = true;
        transform.SetParent(InitialParent);
    }
}
