using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform levelPart;

    void Awake()
    {
        Vector3 spaceDistance = new Vector3(0, 0, 0);
        for (int i = 0; i < 4; i++)
        {
            SpawnPosition(spaceDistance);
            spaceDistance = new Vector3(spaceDistance.x + 4, 0, 0);
        }
    }

    private void SpawnPosition(Vector3 spawnPosition)
    {
        Instantiate(levelPart, spawnPosition, Quaternion.identity);
    }
}