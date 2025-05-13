using UnityEngine;

public class RandomClipPlayer : MonoBehaviour
{
    //array de clips de audio para escoger
    public AudioClip[] clips;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomClip()
    {
        //De un index en random, escoge uno de los clips de la array y lo reproduce
        int index = Random.Range(0, clips.Length);
        audioSource.clip = clips[index];
        audioSource.Play();
    }
}