using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _coinText;
    [SerializeField] private Text _maxScoreText;

    void Update()
    {
        if (GameManager.Instance.CurrentState == GameState.inGame)
        {
            float score = PlayerController.Instance.GetTravelledDistance();
            int coins = GameManager.Instance.CollectedObject;
            float maxScore = PlayerPrefs.GetFloat("maxscore", 0f);

            _scoreText.text = "Score: " + score.ToString("f1");
            _coinText.text = "Coins: " + coins.ToString();
            _maxScoreText.text = "Max Score: " + maxScore.ToString("f1");

        }
    }
}
