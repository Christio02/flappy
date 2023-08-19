using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class LogicManager : MonoBehaviour
{
    [SerializeField] private int playerScore;
    public Text score;
    [SerializeField] TextMeshProUGUI highScoreText;

    [SerializeField] private  GameObject gameOverScreen;
    private BirdScript bird;
    

    [SerializeField] private  AudioSource scoreUpFX;
    [SerializeField] private  AudioSource gameOverFX;
    [SerializeField] private  AudioSource shotgunFX;

    private bool hasPlayedGameOverSound = false; // to not play game over sound anymore


    void Start() {
        Scene currentScene = SceneManager.GetActiveScene (); // get current scene
        string sceneName = currentScene.name; // get scene name

        if (sceneName == "Game") { // Check if scene is game scene, then retrieve birdScript and updateHighscore fro playerPrefs
            bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>(); // need to find the gameobject, and then retrieve the script
            // update highscore at start
            updateHighScoreText();
        }
        

        

        
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
