using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    [SerializeField] private RaceData _raceData;
    [SerializeField] private GameObject _character;
    [SerializeField] private Material _material;
    private int _colorRange;

    void Start()
    {
        _colorRange = Random.Range(0, _raceData._skinPaletteData.Length);
        _character = gameObject;
        _material = _character.GetComponent<SpriteRenderer>().material;
        _material.SetTexture("_MainTex", _raceData._bodyShape.texture);
        _material.SetColor("_Skin", _raceData._skinPaletteData[_colorRange]._skin);
        _material.SetColor("_SkinLightShadow", _raceData._skinPaletteData[_colorRange]._skin_light_shadow);
        _material.SetColor("_SkinNormalShadow", _raceData._skinPaletteData[_colorRange]._skin_normal_shadow);
        _material.SetColor("_SkinDarkShadow", _raceData._skinPaletteData[_colorRange]._skin_dark_shadow);
        _material.SetColor("_SkinBlackShadow", _raceData._skinPaletteData[_colorRange]._skin_black_shadow);
    }
}