using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
                //DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    public List<Furniture> Furnitures;
    public bool IsGameOver;
    public bool IsPopulated;
    public float GameTimer;
    public Text TimerText;
    public Text EndText;
    public GameObject EndGamePanel;


    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            //DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }



    // Use this for initialization
    void Start()
    {
        NewGame();
    }

    public void NewGame()
    {
        if (Furnitures == null)
        {
            Furnitures = new List<Furniture>();
            IsPopulated = false;
            IsGameOver = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (!IsGameOver)
        {
            if (IsPopulated && Furnitures.Count == 0)
            {
                GameOverWin();
            }

            GameTimer -= Time.deltaTime;
            TimerText.text = GameTimer.ToString("F1"); //+ " s. left";
            if (GameTimer <= 0f)
            {
                GameOverLose();
            }
            else if (GameTimer <= 10f && GameTimer > 0f)
            {
                var tsec = (int)((GameTimer - Mathf.Floor(GameTimer)) * 100f);
                TimerText.color = (tsec % 100) > 60 ? Color.white : Color.red;
            } 
        }
    }

    private void GameOverLose()
    {
        IsGameOver = true;
        TimerText.gameObject.SetActive(false);
        GameObject.Find("TimerPanel").SetActive(false);
        EndGamePanel.SetActive(true);
        EndText.text = "Time's Up! You Lose! \n Do you want to play again?";
    }

    private void GameOverWin()
    {
        IsGameOver = true;
        TimerText.gameObject.SetActive(false);
        GameObject.Find("TimerPanel").SetActive(false);
        EndGamePanel.SetActive(true);
        EndText.text = "Congrats! You win! \n Do you want to play again?";
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
