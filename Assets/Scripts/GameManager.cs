using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int languageType = 0;
    [SerializeField] WeekChanger weekChanger;
    
    public int weeks = 1;

    //Unique GameManager
    private static GameManager gameManagerInstance;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (gameManagerInstance == null)
        {
            gameManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeLanguage(int type)
    {
        languageType = type;
    }

    public void NewGameStart()
    {
        SceneManager.LoadScene("Main");
    }
    
    public void ContinueStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
