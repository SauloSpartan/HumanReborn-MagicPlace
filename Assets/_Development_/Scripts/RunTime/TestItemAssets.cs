using UnityEngine;

public class TestItemAssets : MonoBehaviour
{
    public static TestItemAssets Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public Sprite WoodSprite;
    public Sprite RockSprite;
    public Sprite IronSprite;
}
