using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] Button quitButton;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highscoreText;

    public List<TextMeshProUGUI> priceTags;
    public List<Tower> towers;

    public int curScore;
    public int highscore;

    void Awake()
    {
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void Start()
    {
        highscore = ScoreSystem.instance.highscore;
        highscoreText.text = highscore.ToString();

        for(int i = 0; i < priceTags.Count; i++)
        {
            priceTags[i].text = towers[i].cost.ToString();
        }
    }

    private void Update()
    {
        curScore = ScoreSystem.instance.curScore;
        scoreText.text = curScore.ToString();

        if(curScore > highscore)
        {
            highscore = curScore;
            highscoreText.text = highscore.ToString();
        }
    }
    private void RestartGame()
    {
        GameOverManager.instance.SaveHighscore();
        LevelManager.Instance.LoadNewGame();
    }
    private void QuitGame()
    {
        GameOverManager.instance.SaveHighscore();
        LevelManager.Instance.LoadMainMenu();
    }
}
