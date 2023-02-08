using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    [SerializeField] private float _xpAmount; //quitar selialize despues, la experiencia se determinara de otra forma
    [SerializeField] private TestOrbSystem _xpOrb;
    private TestOrbSystem _testOrbSystem;

    /// <summary>
    /// Instantiate an xp orb in this obj position
    /// </summary>
    public void SpawnOrb()
    {
        _testOrbSystem = Instantiate(_xpOrb, transform);
        _testOrbSystem.XpAmount = _xpAmount;
    }

}
