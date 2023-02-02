using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestLevelSystem : MonoBehaviour
{
    [SerializeField] private Text _txtLevel;
    [SerializeField] private Text _txtXpRequired;

    private int _level;
    private float _xpRequired;
    private float _xpActual;

    void Update()
    {
        UIDisplayment();
        LevelUpdate();
    }
    private void UIDisplayment()
    {
        _txtLevel.text = "Lv: " + _level.ToString();
        _txtXpRequired.text = "Next: " + Mathf.Round(_xpRequired - _xpActual).ToString();
    }

    /// <summary>
    /// Updates the level based on the actual xp
    /// </summary>
    private void LevelUpdate()
    {
        _xpRequired = _level * 1.25f + 10;
        if (_xpActual < _xpRequired)
            return;
        _xpActual -= _xpRequired;
        _level++;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("XpOrb"))
            return;

        _xpActual += collision.GetComponent<TestEnemySystem>().XpAmount;
    }
}
