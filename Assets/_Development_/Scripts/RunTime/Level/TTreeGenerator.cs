using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTreeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _trees;
    [SerializeField] private Transform[] _treePosition;

    void Start()
    {
        SpawnTrees();
    }

    private void SpawnTrees()
    {
        int canSpawn;

        for (int i = 0; i < _treePosition.Length; i++)
        {
            canSpawn = Random.Range(0, 3);

            if (canSpawn <= 1)
            {
                Instantiate(_trees[0], _treePosition[i]);
            }
        }
    }
}
