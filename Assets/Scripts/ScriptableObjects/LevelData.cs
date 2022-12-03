using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "BaseData/LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] private Transform[] _levelParts;

    public Transform[] LevelParts { get { return _levelParts; } }
}
