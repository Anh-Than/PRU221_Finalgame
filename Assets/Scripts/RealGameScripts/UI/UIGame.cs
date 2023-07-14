using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] Button quitButton;

    void Awake()
    {
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void RestartGame()
    {
        LevelManager.Instance.LoadNewGame();
    }
    private void QuitGame()
    {
        LevelManager.Instance.LoadMainMenu();
    }
}
