using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public Text ScoreText;
    public GameObject GameOver;
    public GameObject NextLevelGame;
    

   
    

    public static GameController instance;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        
        ScoreText.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
        GameOver.SetActive(true);
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

    public void ShowNextLevel()
    {
        NextLevelGame.SetActive(true);
    }

    public void NextLevel(string lvlName)
    {
         SceneManager.LoadScene(lvlName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }


    
}
