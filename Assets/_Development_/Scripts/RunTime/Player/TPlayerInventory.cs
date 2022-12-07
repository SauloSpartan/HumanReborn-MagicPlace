using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPlayerInventory : MonoBehaviour
{
    [SerializeField] TestUI_Inventory _uiInventory;
    private TestInventory _inventory;

    void Awake()
    {
        _inventory = new TestInventory();
        _uiInventory.SetInventory(_inventory);
    }
}
