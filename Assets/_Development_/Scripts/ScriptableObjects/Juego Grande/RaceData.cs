using UnityEngine;

[CreateAssetMenu(fileName = "RaceData", menuName = "BaseData/RaceData")]
public class RaceData : ScriptableObject
{
    public Race _race;
    public Texture2D _bodyShape;
    public SkinPaletteData[] _skinPaletteData;
}

public enum Race
{
    HUMAN,
    GOBLIN,
    ELF,
}