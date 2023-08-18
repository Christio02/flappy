using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class LogicManager : MonoBehaviour
{
    public int playerScore;
    public Text score;
    [SerializeField] TextMeshProUGUI highScoreText;

    public GameObject gameOverScreen;
    private BirdScript bird;
    

    public AudioSource scoreUpFX;
    public AudioSource gameOverFX;
    public AudioSource shotgunFX;

    private bool hasPlayedGameOverSound = false; // to not play game over sound anymore


    void Start() {
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>(); // need to find the gameobject, and then retrieve the script

        // update highscore at start
        updateHighScoreText();

        
    }
    public void addScore(int scoreToAdd) {
        if (bird.isAlive()) { // check if bird is alive always, otherwise do not increase score
            playerScore += scoreToAdd;
            score.text = playerScore.ToString();
            checkHighScore();
            scoreUpFX.Play();
        }
       
       
    }
 
    void checkHighScore() {
        if (playerScore > PlayerPrefs.GetInt("HighScore", 0)) {
            PlayerPrefs.SetInt("HighScore", playerScore);
        }
    }

    void updateHighScoreText() {
        highScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

    public void playShotgun() {
        shotgunFX.Play();
    }



    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Loads the game scene over
    }


    public void gameOver() {
        gameOverScreen.SetActive(true);
        if (!hasPlayedGameOverSound) { // check if sound has played
            gameOverFX.Play();
            hasPlayedGameOverSound = true;
        }
    }


    public void startGame() {
        SceneManager.LoadScene("Game");
    }

    public void returnToMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void quitApplication() {
        Application.Quit(); // quit application when player presses button
    }
}
