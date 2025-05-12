using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    public TMP_Text info;

    //Nombre de la escena cambiable en el inspector
    public string lvlName;
    private bool inDoor = false;

    //Al triggear con una colision tageada como Player, se muestra un texto
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            info.gameObject.SetActive(true);
            inDoor = true;
        }
    }

    //Al salir de un trigger con una colision tageada como Player se oculta el texto
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            //si info no se ha destruido aún, se desactiva
            if(info != null) { 
                info.gameObject.SetActive(false);
                inDoor = false;
            }
        }
    }

    private void Update()
    {
        //Si se clica e cuando estamos colisionando con el Player (inDoor = true) se cambia de escena
        if (inDoor && Input.GetKey("e")) {
            SceneManager.LoadScene(lvlName);
        }
    }
}
