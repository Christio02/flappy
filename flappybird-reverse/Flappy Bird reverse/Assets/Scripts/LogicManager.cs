using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicManager : MonoBehaviour
{
    public int playerScore;
    public Text score;
    public GameObject gameOverScreen;

    [ContextMenu("Increase score!")]
    public void addScore(int scoreToAdd) {
        playerScore += scoreToAdd;
        score.text = playerScore.ToString();
    }



    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void gameOver() {
        gameOverScreen.SetActive(true);
    }

    public void startGame() {
        SceneManager.LoadScene("Game");
    }

    public void returnToMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void quitApplication() {
        Application.Quit();
    }
}
