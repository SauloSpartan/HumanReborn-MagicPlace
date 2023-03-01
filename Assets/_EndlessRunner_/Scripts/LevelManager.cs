using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private List<LevelBlock> _allLevelBlocks = new List<LevelBlock>();
    [SerializeField] private List<LevelBlock> _currentLevelBlock = new List<LevelBlock>();

    [SerializeField] private Transform _levelStartPosition;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void AddLevelBlock()
    {
        int randomIndex = Random.Range(0, _allLevelBlocks.Count);
        LevelBlock newBlock;
        Vector2 spawnPosition = Vector2.zero;

        if (_currentLevelBlock.Count == 0)
        {
            newBlock = Instantiate(_allLevelBlocks[0]);
            spawnPosition = _levelStartPosition.position;
        }
        else
        {
            newBlock = Instantiate(_allLevelBlocks[randomIndex]);
            spawnPosition = _currentLevelBlock[_currentLevelBlock.Count - 1].EndPoint.position;
        }

        newBlock.transform.SetParent(transform, false);

        Vector2 correction = new Vector2(spawnPosition.x - newBlock.StartPoint.position.x, spawnPosition.y - newBlock.StartPoint.position.y);
        newBlock.transform.position = correction;
        _currentLevelBlock.Add(newBlock);
    }

    public void RemoveLevelBlock()
    {
        LevelBlock oldBlock = _currentLevelBlock[0];
        _currentLevelBlock.Remove(oldBlock);
        Destroy(oldBlock.gameObject);
    }

    public void RemoveAllLevelBlocks()
    {
        while (_currentLevelBlock.Count > 0)
        {
            RemoveLevelBlock();
        }
    }

    public void GenerateInitialBlocks()
    {
        for (int i = 0; i < 3; i++)
        {
            AddLevelBlock();
        }
    }
}
