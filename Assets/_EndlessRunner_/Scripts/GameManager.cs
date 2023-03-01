using UnityEngine;

public enum GameState
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public GameState CurrentState = GameState.menu;

    public static GameManager Instance;

    public int CollectedObject;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void StartGame() 
    {
        SetGameState(GameState.inGame);
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    private void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            MenuManager.Instance.ShowMainMenu();
            MenuManager.Instance.HideGameMenu();
        }
        else if (newGameState == GameState.inGame)
        {
            LevelManager.Instance.RemoveAllLevelBlocks();
            LevelManager.Instance.GenerateInitialBlocks();
            PlayerController.Instance.StartGame();
            MenuManager.Instance.HideMainMenu();
            MenuManager.Instance.ShowGameMenu();
        }
        else if (newGameState == GameState.gameOver)
        {
            MenuManager.Instance.ShowMainMenu();
            MenuManager.Instance.HideGameMenu();
        }

        CurrentState = newGameState;
    }

    public void CollectObject(Collectable collectable)
    {
        CollectedObject += collectable.Value;
    }
}
