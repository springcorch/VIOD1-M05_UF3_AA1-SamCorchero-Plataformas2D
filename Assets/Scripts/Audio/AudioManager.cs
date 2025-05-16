using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    //reproductores de sonido
    public AudioSource musicSource;
    public AudioSource sfxSource;

    //para fade out and fade in
    public float fadeDuration = 1.5f;

    //clips de sonido
    [Header("Music")]
    public AudioClip mainmenuMusic;
    public AudioClip levelsMusic;

    [Header("SFX")]
    public AudioClip nightSFX;
    public AudioClip rainSFX;

    void Awake()
    {
        //Funcion para que no se destruya el objeto al cargar nuevas escenas
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = mainmenuMusic;
        musicSource.Play();
    }

    //Al cambiar de escena, se lo hace saber al audio manager
    void OnEnable() { SceneManager.sceneLoaded += OnSceneLoaded; }
    void OnDisable() { SceneManager.sceneLoaded -= OnSceneLoaded; }

    //funcion para que sepa que cancion tiene que cambiar dependiendo de en que escena este
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //coge el nombre de la escena como caso para asi poder manipularlas a nuestro antojo
        switch (scene.name)
        {
            case "Menu_Main":
                // Solo cambia la musica si no es la que esta sonando
                if (musicSource.clip != mainmenuMusic)
                    TransitionToMusic(mainmenuMusic);
                break;

            case "Cutscene_Intro":
                if (musicSource.clip != mainmenuMusic)
                    TransitionToMusic(mainmenuMusic);
                PlaySFX(nightSFX);
                break;

            case "Tutorial_Movement":
                if (musicSource.clip != levelsMusic)
                    TransitionToMusic(levelsMusic);
                PlaySFX(rainSFX);
                break;

            case "Level_Selector":
                if (musicSource.clip != mainmenuMusic)
                    TransitionToMusic(mainmenuMusic);
                    PlaySFX(nightSFX);
                break;

            case "Level_01":
                if (musicSource.clip != levelsMusic)
                    TransitionToMusic(levelsMusic);
                break;

            default:
                break;
        }
    }

    //transicion entre clips para que no se cambie la musica de golpe
    public void TransitionToMusic(AudioClip newClip)
    {
        //si no se esta reproduciendo nada, no se hace la transicion
        if (musicSource.isPlaying)
        {
            StartCoroutine(FadeOutAndIn(newClip));
        }
        else
        {
            PlayMusic(newClip);
        }
    }

    //courutina para la transicion
    private IEnumerator FadeOutAndIn(AudioClip newClip)
    {
        // Fade out, coge el volumen inicial del clip
        float startVolume = musicSource.volume;

        //Hacemos que el volumen se reduja lentamente entre la duracion que le hemos asignado antes
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }

        //Volumen es ahora 0, se detiene dicha musica
        musicSource.volume = 0;
        musicSource.Stop();

        // Cambio de clip
        musicSource.clip = newClip;
        musicSource.Play();

        // Fade in, lo mismo que antes pero al reves
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            musicSource.volume = Mathf.Lerp(0, startVolume, t / fadeDuration);
            yield return null;
        }

        //Confirmamos que este al volumen de antes
        musicSource.volume = startVolume;
    }

    //Para reproducir musica
    public void PlayMusic(AudioClip clip)
    {
            musicSource.clip = clip;
            musicSource.Play();
    }

    //para reproducir efectos de sonido
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }
}
