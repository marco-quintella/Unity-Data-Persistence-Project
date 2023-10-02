using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreUI : MonoBehaviour
{
    [SerializeField] private Text highScoreText;
    [SerializeField] private InputField inputField;
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
        highScoreText.text = $"High Score :: {ScoreManager.Instance.HighScoreName} :: {ScoreManager.Instance.HighScore}";
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void StartGame()
    {
        ScoreManager.Instance.SetCurrentName(inputField.text);
        SceneManager.LoadScene("main");
    }
}