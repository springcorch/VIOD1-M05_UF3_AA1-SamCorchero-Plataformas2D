using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject questMark;

    //Nombre de la escena cambiable en el inspector
    public string lvlName;
    public PlayerMovement playerM;
    
    private Key key;
    private bool canUnlock = false;
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
            key = FindObjectOfType<Key>();

            if (key != null) {
                if (key.isFollowing) {
                    canUnlock = true;  
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
        //Si se clica e cuando estamos colisionando con el Player (inDoor = true) hace una animacion de abrir puerta
        if (canUnlock && inDoor) 
        {
            questMark.SetActive(true);
            if (Input.GetKey("e"))
            {
                key.DisableKey();
                aud.Play();
                anim.SetBool("isOpen", true);
                playerM.moveSpeed = 0;
                Invoke("LoadLoopScene", 2.0f);
            }
        }

    }

    private void LoadLoopScene()
    {
        SceneManager.LoadScene(lvlName);
    }
}