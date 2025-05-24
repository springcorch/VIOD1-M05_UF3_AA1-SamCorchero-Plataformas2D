using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject questMark;

    //Nombre de la escena cambiable en el inspector
    public string lvlName;

    private bool doorUnlocked = false;
    private bool inDoor = false;

    private Animator anim;
    private AudioSource aud;

    void Start()
    {
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            inDoor = true;

            Key key = FindObjectOfType<Key>();
            if (key != null)
            {
                if (key.isFollowing)
                {
                    key.DisableKey();
                    aud.Play();
                    anim.SetBool("isOpen", true);
                    doorUnlocked = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inDoor = false;
            questMark.SetActive(false);
        }
    }

    private void Update()
    {
        //Si se clica e cuando estamos colisionando con el Player (inDoor = true) se cambia de escena
        if (doorUnlocked && inDoor)
        {
            questMark.SetActive(true);
            if (Input.GetKey("e")) { 
                SceneManager.LoadScene(lvlName);
            }
        }
    }
}