using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;
    public int highScore = 0;

    public Text scoreText;
    public Text highScoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // UI objelerini sahneye göre yeniden bul
        scoreText = GameObject.Find("ScoreText")?.GetComponent<Text>();
        highScoreText = GameObject.Find("HighScoreText")?.GetComponent<Text>();

        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;

        // HighScore kontrolü
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        PlayerPrefs.SetInt("Score", score);
        UpdateScoreUI();
    }

    public void ResetScore()
    {
        score = 0;
        PlayerPrefs.SetInt("Score", 0);
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (highScoreText != null)
        {
            highScore = PlayerPrefs.GetInt("HighScore", 0);
            highScoreText.text = "High Score: " + highScore;
        }
    }
}
