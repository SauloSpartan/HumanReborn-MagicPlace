using UnityEngine;

[CreateAssetMenu(fileName = "RaceData", menuName = "BaseData/RaceData")]
public class RaceData : ScriptableObject
{
    public Race _race;
    public Sprite _bodyShape;
    public SkinPaletteData[] _skinPaletteData;
    public Sprite[] _earShape;
    public Sprite[] _eyeShape;
    public Sprite[] _eyebrowShape;
    public Sprite[] _mouthShape;
    public Sprite[] _backHair;
    public Sprite[] _frontHair;
}

public enum Race
{
    HUMAN,
    GOBLIN,
    ELF,
}