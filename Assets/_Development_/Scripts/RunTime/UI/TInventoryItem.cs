using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TreeEditor;

public class TInventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image _item;
    [HideInInspector] public Transform InitialParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _item.raycastTarget = false;
        InitialParent = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _item.raycastTarget = true;
        transform.SetParent(InitialParent);
    }
}
