using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TMenuManager : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _goBackButton;

    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _optionsMenu;

    [SerializeField] private Button _fullScreenButton;
    [SerializeField] private TMP_Text _fullScreenText;

    void Awake()
    {
        Screen.fullScreen = true;
    }

    void Start()
    {
        _startButton.onClick.AddListener(GameStart);
        _optionsButton.onClick.AddListener(OptionsMenu);
        _goBackButton.onClick.AddListener(MainMenu);
        _fullScreenButton.onClick.AddListener(FullScreen);
    }

    private void GameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OptionsMenu()
    {
        _mainMenu.SetActive(false);
        _optionsMenu.SetActive(true);
    }
    
    private void MainMenu()
    {
        _mainMenu.SetActive(true);
        _optionsMenu.SetActive(false);
    }

    private void FullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;

        if (Screen.fullScreen != true)
        {
            _fullScreenText.text = "FULL SCREEN";
        }
        else
        {
            _fullScreenText.text = "!FULL SCREEN";
        }
    }
}