using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerManager : MonoBehaviour
{
    //Privado pero cambiable en el inspector
    [SerializeField] private AudioMixer mixer;
    //Todos los sliders
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider ambienceSlider;
    public Slider sfxSlider;

    void Start()
    {
        // Cargar valores guardados
        masterSlider.value = PlayerPrefs.GetFloat("Master", 1.0f);
        musicSlider.value = PlayerPrefs.GetFloat("Music", 0.25f);
        ambienceSlider.value = PlayerPrefs.GetFloat("Ambience", 0.50f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFX", 0.35f);

        SetMasterVolume(masterSlider.value);
        SetMusicVolume(musicSlider.value);
        SetAmbienceVolume(ambienceSlider.value);
        SetSFXVolume(sfxSlider.value);
    }

    public void SetMasterVolume(float value)
    {
        mixer.SetFloat("Master", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("Master", value);
    }

    public void SetMusicVolume(float value)
    {
        mixer.SetFloat("Music", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("Music", value);
    }
    public void SetAmbienceVolume(float value)
    {
        mixer.SetFloat("Ambience", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("Ambience", value);
    }

    public void SetSFXVolume(float value)
    {
        mixer.SetFloat("SFX", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("SFX", value);
    }
}