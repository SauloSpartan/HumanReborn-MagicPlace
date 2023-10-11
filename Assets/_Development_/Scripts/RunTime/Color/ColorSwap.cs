using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorSwap : MonoBehaviour
{
    [SerializeField] private Color _colors;
    private SpriteRenderer _sprite;

    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _sprite.color = _colors;
    }
}
