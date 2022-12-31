using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    

    //DEFINE A VARIABLE THAT WILL DEFINE THE playerObject
    public GameObject playerObject;

    //DEFINE A VARIABLE THAT WILL DEFINE THE gameOverScreen
    public GameObject gameOverScreen;

    //USED THROUGHOUT THIS SCRIPT TO DISPLAY UI INFORMATION
    public Text scoreTextUI;
    public int totalPoints;
    public Text gameOverScoreMessage;
    public Text gameTimerUI;

    //USED TO DETERMINE GAME TIME AND TIMER INFO
    public float gameTimer;
    private bool timerIsRunning;

    //DEFINE A VARIABLE THAT WILL DETERMINE WHETHER OR NOT THE GAME IS OVER
    private bool isGameOver;
    private int score;


    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        timerIsRunning = true;
        score = 0;
        scoreTextUI.text = score.ToString() + " OF " + totalPoints;
        gameTimerUI.text = gameTimer.ToString();

    }

    // Update is called once per frame
    void Update()
    {

        if (isGameOver)
        {
            GameOver();
        }

        //IF THE GAME IS OVER AND THE R KEY IS PRESSED THEN...
        if (isGameOver == true && Input.GetKeyDown(KeyCode.R))
        {

            //LOAD THE SCENE CALLED SampleScene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            //SET THE gameOver VARIABLE TO FALSE
            isGameOver = false;

        }

        /**if (totalPoints == score)
        {

            //LOAD THE NEXT SCENE
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }**/

        if (timerIsRunning)
        {
            if (gameTimer > 0)
            {
                
                gameTimer -= Time.deltaTime;
                float minutes = Mathf.FloorToInt(gameTimer / 60);
                float seconds = Mathf.FloorToInt(gameTimer % 60);
                float milliSeconds = (gameTimer % 1) * 100;
                gameTimerUI.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds,milliSeconds);
            }
          
            else
            {

                timerIsRunning = false;
                gameTimer = 0;
                float minutes = 0;
                float seconds = 0;
                float milliSeconds = 0;
                gameTimerUI.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliSeconds);
                isGameOver = true;

            }
        }

    }

    public void IncreaseScore()
    {
        score++;
        scoreTextUI.text = score.ToString() + " OF " + totalPoints;

    }

    public void GameOver()
    {
        //Debug.Log("GAME OVER FUNCTION IS RUNNING");

        //ACTIVATE THE GAME OVER SCREEN
        gameOverScreen.SetActive(true);

        gameOverScoreMessage.text = "YOU COLLECTED: " + score + " of " + totalPoints;

        //DEACTIVATE THE PLAYER OBJECT
        playerObject.SetActive(false);

        //SET THE gameOver VARIABLE TO TRUE
        //isGameOver = true;


    }

   

}
