using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "BaseData/ItemData")]
public class ItemData : ScriptableObject
{
    public enum ItemType
    {
        Wood,
        Rock,
        Iron,
    }

    [SerializeField] private Sprite _itemSprite;
    public ItemType Item { get; }
    [SerializeField] private bool _isStackable;

    public Sprite ItemSprite { get { return _itemSprite; } }
    public bool IsStackable { get { return _isStackable; } }
}
