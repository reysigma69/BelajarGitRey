using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState currentState;

    public GameObject mainMenuPanel;
    public GameObject pausePanel;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //ShowMainMenu(); // mengganti currentState = GameState.Playing;
        string currentScene = SceneManager.GetActiveScene().name;

    if (currentScene == "MainMenu")
    {
        ShowMainMenu();
    }
    else
    {
        // Kalau di scene Game, langsung tancap gas
        StartGame(); 
    }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (currentState == GameState.Playing)
            {
                PauseGame();
            }
            else if (currentState == GameState.Paused) // logika button esc ditambah
            {
                ResumeGame();
            }
        }

    }

    public void ShowMainMenu()  // fungsi main menu
    {
        currentState = GameState.MainMenu;
        Time.timeScale = 0f;
        if (mainMenuPanel)
        {
            mainMenuPanel.SetActive(true);
        }if (pausePanel)
        {
            pausePanel.SetActive(false);
        }
    }

    public void StartGame()  // fungsi start game
    {
        currentState = GameState.Playing;
        Time.timeScale = 1f;
        if(mainMenuPanel)
        {
            mainMenuPanel.SetActive(false);
        }if(pausePanel)
        {
            pausePanel.SetActive(false);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        currentState = GameState.Paused;
        Debug.Log("Game Paused!");  // indikator bahwa game sedang di pause
        if(pausePanel)
        {
            pausePanel.SetActive(true);
        }
    }

    public void ResumeGame() // nambah fungsi ResumeGame
    {
        currentState = GameState.Playing;
        Time.timeScale = 1f;
        Debug.Log("Game Resumed!");
        if(pausePanel)
        {
            pausePanel.SetActive(false);
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        currentState = GameState.GameOver;
        Time.timeScale = 0f;  // timescale biar gamenya stop pas game over
    }

    public void GoToMainMenu() // lupa nambahin fungsi buat pindah tampilan ke main menu
    {
        Debug.Log("Back to Main Menu, gas main lagi :D"); 
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
