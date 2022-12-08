using UnityEngine;
using UnityEngine.UI;

public class TestUI_Inventory : MonoBehaviour
{
    private TestInventory _inventory;
    private Transform _itemSlotContainer;
    private Transform _itemSlotTemplate;
    [SerializeField] RectTransform _itemSlotRectTransform;

    void Awake()
    {
        _itemSlotContainer = transform.Find("ItemSlotContainer");
        _itemSlotTemplate = _itemSlotContainer.Find("ItemSlotTemplate");
    }

    public void SetInventory(TestInventory inventory)
    {
        _inventory = inventory;
        RefreshInventory();
    }

    private void RefreshInventory()
    {
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 143f;

        foreach (TestItem item in _inventory.GetItemList()) 
        {
            RectTransform itemSlotRectTransform = Instantiate(_itemSlotTemplate, _itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);

            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            x++;
            if (x > 3)
            {
                x = 0;
                y++;
            }
        }
    }
}
