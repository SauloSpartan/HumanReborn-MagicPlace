using System.Collections.Generic;
using UnityEngine;

public class TestInventory
{
    private List<TestItem> _itemList;

    public TestInventory()
    {
        _itemList = new List<TestItem>();

        AddItem(new TestItem { TypeItem = TestItem.ItemType.Rock, amount = 1 });
        AddItem(new TestItem { TypeItem = TestItem.ItemType.Wood, amount = 1 });
        AddItem(new TestItem { TypeItem = TestItem.ItemType.Iron, amount = 1 });
    }

    public void AddItem(TestItem item)
    {
        _itemList.Add(item);
    }

    public List<TestItem> GetItemList()
    {
        return _itemList;
    }
}
