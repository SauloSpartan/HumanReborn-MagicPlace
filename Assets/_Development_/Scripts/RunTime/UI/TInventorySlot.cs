using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// On "InventorySlot", manage the spaces on inventory using Unity Interfaces.
public class TInventorySlot : MonoBehaviour, IDropHandler
{
    private Image _image;
    private Color selectedColor;
    private Color notSelectedColor;

    void Awake()
    {
        _image = GetComponent<Image>();
        selectedColor = Color.red;
        notSelectedColor = Color.white;

        Deselect();
    }

    public void Select()
    {
        _image.color  = selectedColor;
    }

    public void Deselect()
    {
        _image.color = notSelectedColor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            TInventoryItem inventoryItem = eventData.pointerDrag.GetComponent<TInventoryItem>();
            inventoryItem.InitialParent = transform;
        }
    }
}
