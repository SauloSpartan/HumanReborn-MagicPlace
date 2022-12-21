using UnityEngine;
using UnityEditor.UI;

public class TShowInventory : MonoBehaviour
{
    private GameObject _mainInventory;
    [SerializeField] private bool _showInventory;

    void Awake()
    {
        _mainInventory = GameObject.Find("InventoryGroup");
        _mainInventory.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && _showInventory == false)
        {
            _mainInventory.SetActive(true);
            _showInventory = true;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && _showInventory == true)
        {
            _mainInventory.SetActive(false);
            _showInventory = false;
        }
    }
}
