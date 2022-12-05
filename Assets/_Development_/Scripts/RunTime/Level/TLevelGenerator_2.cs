using UnityEngine;

public class TLevelGenerator_2 : MonoBehaviour
{
    [SerializeField] private LevelData _levelData;
    [SerializeField] private int _levelSize;

    void Awake()
    {
        Vector3 spaceDistance = new Vector3(4, 0, 0);
        int _randomNumber;
        for (int i = 0; i < _levelSize; i++)
        {
            _randomNumber = Random.Range(0, 3);
            SpawnPosition(spaceDistance, _randomNumber);
            spaceDistance = new Vector3(spaceDistance.x + 15, 0, 0);
        }
    }

    private void SpawnPosition(Vector3 spawnPosition, int levelNumber)
    {
        Instantiate(_levelData.LevelParts[levelNumber], spawnPosition, Quaternion.identity);
    }
}
