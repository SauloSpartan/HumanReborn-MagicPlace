using UnityEngine;

public class TestItem
{
    public enum ItemType
    {
        Wood,
        Rock,
        Iron,
    }

    public ItemType TypeItem;
    public int amount;

    public Sprite GetSprite()
    {
        switch (TypeItem)
        {
            default:
            case ItemType.Wood: return TestItemAssets.Instance.WoodSprite;
            case ItemType.Rock: return TestItemAssets.Instance.RockSprite;
            case ItemType.Iron: return TestItemAssets.Instance.IronSprite;
        }
    }
}