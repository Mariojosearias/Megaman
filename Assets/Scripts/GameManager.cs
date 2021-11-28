using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject NextLevel;
    
    public bool isRunning;
    private UIManager uiManager;
    private bool blackoutActivated;
    public int numEnemys;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        blackoutActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void NextLvl(int nivel)
    {
        SceneManager.LoadSceneAsync(nivel);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
        }
    }
    public void CaptureEnemy()
    {
        numEnemys--;
        if(numEnemys < 1)
        {
            Time.timeScale = 0;
            NextLevel.SetActive(true);
        }
    }
    public void BlackoutFunction()
    {
        blackoutActivated = !blackoutActivated;
        if (blackoutActivated)
        {
            uiManager.SetBlackoutOpacity(1);
        }
        else
        {
            uiManager.SetBlackoutOpacity(0);}
        }
    
    public bool Running()
        {
            return isRunning;
        }
}


