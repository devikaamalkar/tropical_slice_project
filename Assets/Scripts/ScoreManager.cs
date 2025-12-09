using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("UI")]
    public TMP_Text scoreText;
    public TMP_Text missText;
    public GameObject gameOverPanel;
    public GameObject sliceManager;   


    private int score = 0;
    private int misses = 0;
    public int maxMisses = 3;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateScoreText();
        UpdateMissText();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public void AddMiss()
    {
        misses++;
        UpdateMissText();

        if (misses >= maxMisses)
        {
            GameOver();
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    void UpdateMissText()
    {
        if (missText != null)
            missText.text = "Missed: " + misses;
    }

    void GameOver()
    {
        Time.timeScale = 0f; // pause game

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        if (sliceManager != null)
            sliceManager.SetActive(false);   // 👈 turn off trail + slicing
    }

}
