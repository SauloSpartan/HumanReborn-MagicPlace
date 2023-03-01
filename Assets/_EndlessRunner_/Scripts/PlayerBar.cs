using UnityEngine;
using UnityEngine.UI;

public enum BarType
{
    healthBar,
    manaBar
}

public class PlayerBar : MonoBehaviour
{
    private Slider _slider;
    public BarType Type;

    void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    void Start()
    {
        switch (Type)
        {
            case BarType.healthBar:
                _slider.maxValue = PlayerController.Max_Health;
                break;
            case BarType.manaBar:
                _slider.maxValue = PlayerController.Max_Mana;
                break;
        }
    }

    void Update()
    {
        switch (Type)
        {
            case BarType.healthBar:
                _slider.value = PlayerController.Instance.GetHealth();
                break;
            case BarType.manaBar:
                _slider.value = PlayerController.Instance.GetMana();
                break;
        }
    }
}