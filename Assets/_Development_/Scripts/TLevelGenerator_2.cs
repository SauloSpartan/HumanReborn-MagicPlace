using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLevelGenerator_2 : MonoBehaviour
{
    [SerializeField] private LevelData _levelData;

    void Awake()
    {
        Vector3 spaceDistance = new Vector3(0, 0, 0);
        int _randomNumber;
        for (int i = 0; i < 4; i++)
        {
            _randomNumber = Random.Range(0, 3);
            SpawnPosition(spaceDistance, _randomNumber);
            spaceDistance = new Vector3(spaceDistance.x + 4, 0, 0);
        }
    }

    private void SpawnPosition(Vector3 spawnPosition, int levelNumber)
    {
        Instantiate(_levelData.LevelParts[levelNumber], spawnPosition, Quaternion.identity);
    }
}
