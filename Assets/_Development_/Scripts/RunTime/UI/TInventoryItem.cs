using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TreeEditor;

public class TInventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private ItemData _item;
    private Image _image;
    [HideInInspector] public Transform InitialParent;

    void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void InitialiseItem(ItemData newItem)
    {
        _item = newItem;
        _image.sprite = newItem.ItemSprite;
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
