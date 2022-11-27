using UnityEngine;

[CreateAssetMenu(fileName = "HumanoidData", menuName = "BaseData/HumanoidData")]
public class HumanoidData : ScriptableObject
{
    [SerializeField] private Renderer[] _characterSkin;

    public Renderer[] CharacterSkin { get { return _characterSkin; } set { _characterSkin = value; } }
}