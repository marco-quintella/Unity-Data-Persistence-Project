using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int HighScore { get; private set; }
    public string HighScoreName { get; private set; }
    
    public string CurrentName { get; private set; }
    public int CurrentScore { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Instance = this;
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        HighScore = PlayerPrefs.GetInt("BestScore");
        HighScoreName = PlayerPrefs.GetString("BestName");
    }

    private void OnDestroy()
    {
        if (CurrentScore > HighScore) return;
        PlayerPrefs.SetString("BestName", CurrentName);
        PlayerPrefs.SetInt("BestScore", CurrentScore);
    }

    public void SetCurrentName(string newName)
    {
        CurrentName = newName;
    }

    public void SetCurrentScore(int newHighScore)
    {
        CurrentScore = newHighScore;
    }

    public void UpdateScore()
    {
        PlayerPrefs.SetString("BestName", CurrentName);
        PlayerPrefs.SetInt("BestScore", CurrentScore);
        Start();
    }
}