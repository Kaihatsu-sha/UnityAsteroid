using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    public static GameScript instance;
    public UnityEngine.UI.Text scoreLabel;
    public UnityEngine.UI.Image image;
    public UnityEngine.UI.Text pressLabel;
    public UnityEngine.UI.Text lostLabel;

    private int score = 0;
    //private bool isActive = false;
    private bool isFirst = true;
    private bool isPause = false;

    public bool isLost = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Time.timeScale = 0;
        scoreLabel.enabled = false;
        lostLabel.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        MyPause();
        StartGame();

        LostMenu();
    }

    public void IncreaseScore(int increment)
    {
        score += increment;

        scoreLabel.text = "Score: " + score;
    }

    private void StartGame()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isFirst)
        {
            Time.timeScale = 1;
            image.enabled = false;
            pressLabel.enabled = false;
            
            //isStart = true;
            isFirst = false;
            scoreLabel.enabled = true;
        }
    }

    private void MyPause()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!isPause)
            {
                Time.timeScale = 0;
                isPause = true;
            }
            else
            {
                Time.timeScale = 1;
                isPause = false;
            }
        }
    }

    public void LostMenu()
    {
        if (isLost)
        {
            Time.timeScale = 0;
            lostLabel.enabled = true;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;

                lostLabel.enabled = false;
                isLost = false;
            }

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                Application.Quit();
            }
        }
        
    }
}
