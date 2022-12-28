using System.Net.Sockets;
using UnityEngine;
using UnityEngine.EventSystems;

// On "InventorySlot", manage the spaces on inventory using Unity Interfaces.
public class TInventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            TInventoryItem inventoryItem = eventData.pointerDrag.GetComponent<TInventoryItem>();
            inventoryItem.InitialParent = transform;
        }
    }
}
