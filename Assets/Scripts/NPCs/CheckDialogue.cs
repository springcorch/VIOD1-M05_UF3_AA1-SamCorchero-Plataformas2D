using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CheckDialogue : MonoBehaviour
{
    //questMark and dialogueBox marcable en el inspector
    public GameObject questMark;
    public GameObject dialogueBox;

    //Nuestro trigger ha entrado en una colisi�n
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If la colision detectada esta marcada con el tag Player
        if (collision.CompareTag("Player"))
        {
            //Se mostrara la questMark
            questMark.SetActive(true);
        }
    }

    //Mientras el trigger este en contacto con la colisi�n
    private void OnTriggerStay2D(Collider2D collision)
    {
        //si se pulsa "e" se activara el dialogo
        if (Input.GetKey("e"))
        {
            dialogueBox.SetActive(true);
            Destroy(questMark);
            Destroy(gameObject);
        }
    }
    //Nuestro trigger ha salido de esa colisi�n
    private void OnTriggerExit2D(Collider2D collision)
    {
        //If la colision detectada esta marcada con el tag Player
        if (collision.CompareTag("Player"))
        {
            //Se ocultara la questMark
            questMark.SetActive(false);

        }
    }
}
