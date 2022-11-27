using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRenderer : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private float _offset;
    [SerializeField] private float _tiling;

    void Start()
    {
        
    }

    void Update()
    {
        _renderer.material.mainTextureOffset = new Vector2(_offset, 0);
        _renderer.material.SetTextureScale("_MainTex", new Vector2(_tiling, 1));
    }
}
