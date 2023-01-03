using UnityEngine;

// On "InventoryManager", manages to add items in your inventory.
public class TInventoryManager : MonoBehaviour
{
    [SerializeField] private TInventorySlot[] _inventorySlots;
    [SerializeField] private GameObject _itemPrefab;

    private int _selectedSlot = -1;

    void Start()
    {
        ChangeSelectedSlot(0);
    }

    void Update()
    {
        GetNumberInput();
    }

    /// <summary>
    /// Gets the inputs of numbers to select an inventory slot.
    /// </summary>
    private void GetNumberInput()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < 6)
            {
                ChangeSelectedSlot(number - 1);
            }
        }
    }

    /// <summary>
    /// Moves the selected slot to a new one.
    /// </summary>
    /// <param name="newValue"> Gets an int for the value of the slot selected.</param>
    private void ChangeSelectedSlot(int newValue)
    {
        if (_selectedSlot >= 0)
        {
            _inventorySlots[_selectedSlot].Deselect();
        }

        _inventorySlots[newValue].Select();
        _selectedSlot = newValue;
    }

    /// <summary>
    /// Adds and moves items when picked up or drag and droped.
    /// </summary>
    /// <param name="item"> Receives and ItemData parameter to work with.</param>
    /// <returns> Returns true if you had space on the inventory to add an item and false if not.</returns>
    public bool AddItem(ItemData item)
    {
        for (int i = 0; i < _inventorySlots.Length; i++)
        {
            TInventorySlot slot = _inventorySlots[i];
            TInventoryItem itemInSlot = slot.GetComponentInChildren<TInventoryItem>();

            // Find any empty slot
            if (itemInSlot == null)
            {
                ShowOnInventory(item, slot);
                return true;
            }

            // Check for same item in slot with count lower than max
            else if (itemInSlot != null && itemInSlot.Item == item && itemInSlot.Count < 5 && itemInSlot.Item.IsStackable == true)
            {
                itemInSlot.Count++;
                itemInSlot.RefreshCount(true);
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