using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform levelPart;

    void Awake()
    {
        Instantiate(levelPart, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void Update()
    {
        
    }
}
