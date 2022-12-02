using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRenderer : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {

    }

    public void TestFlipMaterial(float tiling, float offset)
    {
        _renderer.material.SetTextureScale("_MainTex", new Vector2(tiling, 1));
        _renderer.material.mainTextureOffset = new Vector2(offset, 0);
    }
}