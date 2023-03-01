using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    [SerializeField] private Canvas _menuCanvas;
    [SerializeField] private Canvas _gameCanvas;
    [SerializeField] private Canvas _deathCanvas;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ShowMainMenu()
    {
        _menuCanvas.enabled = true;
    }
    
    public void HideMainMenu()
    {
        _menuCanvas.enabled = false;
    }

    public void ShowGameMenu()
    {
        _gameCanvas.enabled = true;
    }

    public void HideGameMenu()
    {
        _gameCanvas.enabled = false;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
