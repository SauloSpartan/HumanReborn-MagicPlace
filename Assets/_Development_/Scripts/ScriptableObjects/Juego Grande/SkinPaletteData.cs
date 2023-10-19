using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinPaletteData", menuName = "BaseData/SkinPaletteData")]
public class SkinPaletteData : ScriptableObject
{
    public Color _skin;
    public Color _skin_light_shadow;
    public Color _skin_normal_shadow;
    public Color _skin_dark_shadow;
    public Color _skin_black_shadow;
}