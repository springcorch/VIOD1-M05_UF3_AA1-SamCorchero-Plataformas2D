using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private RandomClipPlayer _player;

    public GameObject whiteBox;
    public GameObject settings;
    public GameObject credits;

    void Start()
    {
        _player = GetComponent<RandomClipPlayer>();
        whiteBox.SetActive(false);
        settings.SetActive(false);
        credits.SetActive(false);
    }
    public void StartButton()
    {
        _player.PlayRandomClip();
        Invoke("ChangeScene", 0.5f);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Cutscene_Intro");
    }

    public void Settings()
    {
        //ahora mismo no graficos ni sonido tiene xd
        _player.PlayRandomClip();
        whiteBox.SetActive(true);
        settings.SetActive(true);
    }

    public void Credits()
    {
        _player.PlayRandomClip();
        whiteBox.SetActive(true);
        credits.SetActive(true);
    }
    public void Back()
    {
        _player.PlayRandomClip();
        whiteBox.SetActive(false);
        settings.SetActive(false);
        credits.SetActive(false);
    }

    public void QuitGame()
    {
        _player.PlayRandomClip();
        Application.Quit();
    }
}
