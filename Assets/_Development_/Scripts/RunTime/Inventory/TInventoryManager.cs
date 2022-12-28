using UnityEngine;

// On "InventoryManager", manages to add items in your inventory.
public class TInventoryManager : MonoBehaviour
{
    [SerializeField] private TInventorySlot[] _inventorySlots;
    [SerializeField] private GameObject _itemPrefab;

    public bool AddItem(ItemData item)
    {
        // Check for same item in slot with count lower than max
        for (int i = 0; i < _inventorySlots.Length; i++)
        {
            TInventorySlot slot = _inventorySlots[i];
            TInventoryItem itemInSlot = slot.GetComponentInChildren<TInventoryItem>();
            if (itemInSlot != null && itemInSlot.Item == item && itemInSlot.Count < 5 && itemInSlot.Item.IsStackable == true)
            {
                itemInSlot.Count++;
                itemInSlot.RefreshCount(true);
                return true;
            }
        }

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