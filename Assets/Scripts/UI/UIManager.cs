using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    private RandomClipPlayer _player;


    private void Start()
    {
        _player = GetComponent<RandomClipPlayer>();
    }

    public void PauseMenu()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        //Un scrip que reproduce un audio aleatorio de una array
        _player.PlayRandomClip();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        _player.PlayRandomClip();
    }

    public void Settings()
    {
        //ahora mismo no gráficos ni sonido tiene xd
        _player.PlayRandomClip();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        _player.PlayRandomClip();
        SceneManager.LoadScene("Menu_Main");
    }

    public void QuitGame() {
        _player.PlayRandomClip();
        Application.Quit();
    }
}
