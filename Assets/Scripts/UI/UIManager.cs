using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingPanel;
    private RandomClipPlayer _player;


    private void Start()
    {
        _player = GetComponent<RandomClipPlayer>();
    }

    public void PauseMenu()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        settingPanel.SetActive(false);
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
        _player.PlayRandomClip();
        settingPanel.SetActive(true);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        _player.PlayRandomClip();
        SceneManager.LoadScene("Menu_Main");
    }

    public void QuitGame() {
        Time.timeScale = 1;
        _player.PlayRandomClip();
        Application.Quit();
    }
}
