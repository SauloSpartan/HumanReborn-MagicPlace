using System.Collections.Generic;
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
    [SerializeField] private TMP_Dropdown _screenResolution;
    private string[] _resolutionSizes = { "800x600", "1024x768", "1152x864", "1280x720", "1280x768", "1280x1024", "1360x768", "1366x768", "1600x900", "1600x1024", "1920x1080" };

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
        ResolutionDropdown();
        _screenResolution.onValueChanged.AddListener(delegate {ScreenResolution(); });
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

    private void ResolutionDropdown()
    {
        foreach (string size in _resolutionSizes)
        {
            _screenResolution.options.Add(new TMP_Dropdown.OptionData() { text = size });
        }
    }

    private void ScreenResolution()
    {
        switch (_resolutionSizes[_screenResolution.value])
        {
            case "800x600":
                Screen.SetResolution(800, 600, Screen.fullScreen, 1);
                break;

            case "1024x768":
                Screen.SetResolution(1024, 768, Screen.fullScreen, 1);
                break;

            case "1152x864":
                Screen.SetResolution(1152, 864, Screen.fullScreen, 1);
                break;

            case "1280x720":
                Screen.SetResolution(1280, 720, Screen.fullScreen, 1);
                break;

            case "1280x768":
                Screen.SetResolution(1280, 768, Screen.fullScreen, 1);
                break;

            case "1280x1024":
                Screen.SetResolution(1280, 1024, Screen.fullScreen, 1);
                break;

            case "1360x768":
                Screen.SetResolution(1360, 768, Screen.fullScreen, 1);
                break;

            case "1366x768":
                Screen.SetResolution(1366, 768, Screen.fullScreen, 1);
                break;

            case "1600x900":
                Screen.SetResolution(1600, 900, Screen.fullScreen, 1);
                break;

            case "1600x1024":
                Screen.SetResolution(1600, 1024, Screen.fullScreen, 1);
                break;

            case "1920x1080":
                Screen.SetResolution(1920, 1080, Screen.fullScreen, 1);
                break;
        }
    }
}