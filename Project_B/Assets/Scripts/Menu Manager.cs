using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    private GameObject mainMenu;
    private GameObject creditsMenu;
    private GameObject pauseMenu;
    private GameObject gameHUD;
    private GameObject gameOverMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainMenu = GameObject.FindGameObjectWithTag("MainMenu");
        creditsMenu = GameObject.FindGameObjectWithTag("CreditsMenu");
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        gameHUD = GameObject.FindGameObjectWithTag("HUD");
        gameOverMenu = GameObject.FindGameObjectWithTag("GameOverMenu");

        if (creditsMenu != null) creditsMenu.SetActive(false);
        if (pauseMenu != null) pauseMenu.SetActive(false);
        if (gameOverMenu != null) gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartClick()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void OnCreditsClick()
    {
        if (mainMenu != null) mainMenu.SetActive(false);
        if (creditsMenu != null) creditsMenu.SetActive(true);
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

    public void OnCreditsBackClick()
    {
        if (creditsMenu != null) creditsMenu.SetActive(false);
        if (mainMenu != null) mainMenu.SetActive(true);
    }

    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }

    public void OnGameplayPause()
    {
        if (pauseMenu != null) pauseMenu.SetActive(true);
        if (gameHUD != null) gameHUD.SetActive(false);
    }

    public void OnResumeClick()
    {
        if (pauseMenu != null) pauseMenu.SetActive(false);
        if (gameHUD != null) gameHUD.SetActive(true);
    }
}
