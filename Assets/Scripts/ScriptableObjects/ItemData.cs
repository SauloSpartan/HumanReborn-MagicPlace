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

    public ItemType Type;
    [SerializeField] private Sprite _itemSprite;
    [SerializeField] private bool _isStackable = false;

    public Sprite ItemSprite { get { return _itemSprite; } }
    public bool IsStackable { get { return _isStackable; } }
}
