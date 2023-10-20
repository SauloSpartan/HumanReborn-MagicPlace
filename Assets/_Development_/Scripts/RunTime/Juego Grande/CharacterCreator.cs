using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreator : MonoBehaviour
{
    [SerializeField] private RaceData _raceData;
    [SerializeField] private Material _skin_material;
    [SerializeField] private Material _hair_material;
    [SerializeField] private Material _eye_material;
    [SerializeField] private Material _default_material;
    private int _randomizer;

    void Start()
    {
        _eye_material = _hair_material;

        CharacterGeneration();
        SkinColorAssing();
        HairColorAssing();
        EyeColorAssing();
    }

    private void CharacterGeneration()
    {
        GameObject _characterBody = new GameObject("Body", typeof(SpriteRenderer));
        _characterBody.GetComponent<SpriteRenderer>().sprite = _raceData._bodyShape;
        _characterBody.GetComponent<SpriteRenderer>().material = _skin_material;
        _skin_material = _characterBody.GetComponent<SpriteRenderer>().material;
        _characterBody.GetComponent<SpriteRenderer>().sortingOrder = 1;

        _randomizer = Random.Range(0, _raceData._earShape.Length);
        GameObject _ears = new GameObject("Ears", typeof(SpriteRenderer));
        _ears.transform.parent = _characterBody.transform;
        _ears.GetComponent<SpriteRenderer>().sprite = _raceData._earShape[_randomizer];
        _ears.GetComponent<SpriteRenderer>().material = _skin_material;
        _ears.GetComponent<SpriteRenderer>().sortingOrder = 3;

        _randomizer = Random.Range(0, _raceData._mouthShape.Length);
        GameObject _mouth = new GameObject("Mouth", typeof(SpriteRenderer));
        _mouth.transform.parent = _characterBody.transform;
        _mouth.GetComponent<SpriteRenderer>().sprite = _raceData._mouthShape[_randomizer];
        _mouth.GetComponent<SpriteRenderer>().material = _skin_material;
        _mouth.GetComponent<SpriteRenderer>().sortingOrder = 4;

        _randomizer = Random.Range(0, _raceData._frontHair.Length);
        GameObject _hair_front = new GameObject("Front Hair", typeof(SpriteRenderer));
        _hair_front.transform.parent = _characterBody.transform;
        _hair_front.GetComponent<SpriteRenderer>().sprite = _raceData._frontHair[_randomizer];
        _hair_front.GetComponent<SpriteRenderer>().material = _hair_material;
        _hair_material = _hair_front.GetComponent<SpriteRenderer>().material;
        _hair_front.GetComponent<SpriteRenderer>().sortingOrder = 7;

        _randomizer = Random.Range(0, _raceData._backHair.Length);
        GameObject _hair_back = new GameObject("Back Hair", typeof(SpriteRenderer));
        _hair_back.transform.parent = _characterBody.transform;
        _hair_back.GetComponent<SpriteRenderer>().sprite = _raceData._backHair[_randomizer];
        _hair_back.GetComponent<SpriteRenderer>().material = _hair_material;
        _hair_back.GetComponent<SpriteRenderer>().sortingOrder = 0;

        _randomizer = Random.Range(0, _raceData._eyebrowShape.Length);
        GameObject _eyebrows = new GameObject("Back Hair", typeof(SpriteRenderer));
        _eyebrows.transform.parent = _characterBody.transform;
        _eyebrows.GetComponent<SpriteRenderer>().sprite = _raceData._eyebrowShape[_randomizer];
        _eyebrows.GetComponent<SpriteRenderer>().material = _default_material;
        _eyebrows.GetComponent<SpriteRenderer>().sortingOrder = 6;

        _randomizer = Random.Range(0, _raceData._eyeShape.Length);
        GameObject _eyes = new GameObject("Back Hair", typeof(SpriteRenderer));
        _eyes.transform.parent = _characterBody.transform;
        _eyes.GetComponent<SpriteRenderer>().sprite = _raceData._eyeShape[_randomizer];
        _eyes.GetComponent<SpriteRenderer>().material = _eye_material;
        _eye_material = _eyes.GetComponent<SpriteRenderer>().material;
        _eyes.GetComponent<SpriteRenderer>().sortingOrder = 5;
    }

    private void SkinColorAssing()
    {
        _randomizer = Random.Range(0, _raceData._skinPaletteData.Length);
        _skin_material.SetTexture("_MainTex", _raceData._bodyShape.texture);
        _skin_material.SetColor("_Skin", _raceData._skinPaletteData[_randomizer]._skin);
        _skin_material.SetColor("_SkinLightShadow", _raceData._skinPaletteData[_randomizer]._skin_light_shadow);
        _skin_material.SetColor("_SkinNormalShadow", _raceData._skinPaletteData[_randomizer]._skin_normal_shadow);
        _skin_material.SetColor("_SkinDarkShadow", _raceData._skinPaletteData[_randomizer]._skin_dark_shadow);
        _skin_material.SetColor("_SkinBlackShadow", _raceData._skinPaletteData[_randomizer]._skin_black_shadow);
    }

    private void HairColorAssing()
    {
        _hair_material.SetTexture("_MainTex", _raceData._bodyShape.texture);
        Color colour = new Color(Random.value, Random.value, Random.value);
        _hair_material.SetColor("_HairColor", colour);
    }

    private void EyeColorAssing()
    {
        _eye_material.SetTexture("_MainTex", _raceData._bodyShape.texture);
        Color colour = new Color(Random.value, Random.value, Random.value);
        _eye_material.SetColor("_HairColor", colour);
    }
}