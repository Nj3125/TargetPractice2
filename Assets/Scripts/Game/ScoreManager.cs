using TMPro;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    public int currentScore;

    private void Awake()
    {
        if (scoreText == null) { Debug.LogError("ScoreManager: No scoreText assigned in the Inspector!", this); }
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null) { scoreText.text = "Score: " + currentScore.ToString(); }
    }

    public void WriteScoreToFile()
    {
        string path = Path.Combine(Application.persistentDataPath, "score.json");
        File.AppendAllText(path, currentScore.ToString() + "\n");
        Debug.Log("Saved score " + currentScore + " to path " + path);
    }
}