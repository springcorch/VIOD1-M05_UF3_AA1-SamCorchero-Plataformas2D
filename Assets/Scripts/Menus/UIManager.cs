using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;

    public void PauseMenu()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void Settings()
    {
        //ahora mismo no gráficos ni sonido tiene xd
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Town");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
