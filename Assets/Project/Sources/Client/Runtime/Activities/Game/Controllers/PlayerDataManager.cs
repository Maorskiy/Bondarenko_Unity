using UnityEngine;
using TMPro; 

public class PlayerDataManager : MonoBehaviour
{
    private const string HighScoreKey = "HighScore";

    public TextMeshProUGUI highScoreText; 
    public TextMeshProUGUI currentScoreText; 

    private int currentScore;

    private void Start()
    {
        int highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        highScoreText.text = "High Score: " + highScore;
        currentScore = 0;
        UpdateCurrentScoreText();
    }

    public void AddScore(int points)
    {
        currentScore += points;
        UpdateCurrentScoreText();

        if (currentScore > PlayerPrefs.GetInt(HighScoreKey, 0))
        {
            PlayerPrefs.SetInt(HighScoreKey, currentScore);
            PlayerPrefs.Save();
            highScoreText.text = "High Score: " + currentScore;
        }
    }

    private void UpdateCurrentScoreText()
    {
        currentScoreText.text = "Score: " + currentScore;
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey(HighScoreKey);
        highScoreText.text = "High Score: 0";
    }
}
