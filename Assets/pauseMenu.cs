using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    public GameObject tenueDescaladeUI;

    public Inventaire inventaire;

    void Start()
    {
        tenueDescaladeUI.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void activeTenueDEscaladeUI()
    {
        tenueDescaladeUI.SetActive(true);
    }

    public void resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void mettreTenueDescalade()
    {
        if(inventaire.tenueDEscaladeInvent)
        {
            if(inventaire.tenueDEscalade == false)
            {
                inventaire.tenueDEscalade = true;
            }
            else
            {
                inventaire.tenueDEscalade = false;
            }
        }
    }
}
