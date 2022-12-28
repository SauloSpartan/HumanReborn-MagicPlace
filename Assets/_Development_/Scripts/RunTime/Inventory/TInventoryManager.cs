using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TInventoryManager : MonoBehaviour
{
    [SerializeField] private TInventorySlot[] _inventorySlots;
    [SerializeField] private GameObject _itemPrefab;

    public bool AddItem(ItemData item)
    {
        // Find any empty slot
        for (int i = 0; i < _inventorySlots.Length; i++)
        {
            TInventorySlot slot = _inventorySlots[i];
            TInventoryItem itemInSlot = slot.GetComponentInChildren<TInventoryItem>();
            if (itemInSlot == null)
            {
                ShowOnInventory(item, slot);
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Spawns a new item on the inventory to be shown.
    /// </summary>
    /// <param name="item"> Needs an ItemData reference.</param>
    /// <param name="slot"> Needs a InvetorySlot reference.</param>
    private void ShowOnInventory(ItemData item, TInventorySlot slot)
    {
        GameObject newItem = Instantiate(_itemPrefab, slot.transform);
        TInventoryItem inventoryItem = newItem.GetComponent<TInventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
}