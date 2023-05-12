using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TMenuManager : MonoBehaviour
{
    [SerializeField] private Button _gameStart;

    void Start()
    {
        _gameStart.onClick.AddListener(GameStart);
    }

    private void GameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}