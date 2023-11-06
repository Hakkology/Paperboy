using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager
{
    private TextMeshProUGUI scoreText;
    private List<Image> heartImages;
    private int score = 0;
    private int lives = 3;
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                throw new System.Exception("UIManager has not been initialized.");
            }
            return instance;
        }
    }

    public static void Initialize(TextMeshProUGUI scoreTextComponent, List<Image> heartImagesList)
    {
        if (instance != null)
        {
            Debug.LogWarning("UIManager is already initialized.");
            return;
        }

        instance = new UIManager(scoreTextComponent, heartImagesList);
    }

    private UIManager(TextMeshProUGUI scoreTextComponent, List<Image> heartImagesList)
    {
        this.scoreText = scoreTextComponent;
        this.heartImages = heartImagesList;

        UpdateScoreDisplay();
        UpdateLivesDisplay();
    }

    public void AddScore(int increment)
    {
        score += increment;
        UpdateScoreDisplay();
    }

    public void LoseLife()
    {
        if (lives > 0)
        {
            lives--;
            UpdateLivesDisplay();
        }
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
            scoreText.text = $"Score: {score}";
    }

    private void UpdateLivesDisplay()
    {
        if (heartImages != null)
        {
            for (int i = 0; i < heartImages.Count; i++)
            {
                heartImages[i].enabled = i < lives;
            }
        }
    }
}
