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
    private BirdScript bird;
    

    public AudioSource scoreUpFX;
    public AudioSource gameOverFX;
    public AudioSource shotgunFX;

    private bool hasPlayedGameOverSound = false; // to not play game over sound anymore

    

    [ContextMenu("Increase score!")]

    void Start() {
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>(); // need to find the gameobject, and then retrieve the script
        
    }
    public void addScore(int scoreToAdd) {
        if (bird.isAlive()) { // check if bird is alive always, otherwise do not increase score
            playerScore += scoreToAdd;
            score.text = playerScore.ToString();
            scoreUpFX.Play();
        }
       
       
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
