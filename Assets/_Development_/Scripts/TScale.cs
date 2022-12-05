using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TScale : MonoBehaviour
{
    [SerializeField] private float _scale = 1;

    void Awake()
    {
        gameObject.transform.localScale = new Vector3(_scale, _scale, _scale);
    }
}
