using UnityEngine;

public class CheckDialogue : MonoBehaviour
{
    //questMark and dialogues marcable en el inspector
    public GameObject questMark;
    public GameObject dialogue1;

    //Nuestro trigger ha entrado en una colisión
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If la colision detectada esta marcada con el tag Player
        if (collision.CompareTag("Player"))
        {
            //Se mostrara la questMark
            questMark.SetActive(true);
        }
    }

    //Mientras el trigger este en contacto con la colisión
    private void OnTriggerStay2D(Collider2D collision)
    {
        //si se pulsa "e" se activara el dialogo
        if (Input.GetKey("e"))
        {
            dialogue1.SetActive(true);
            Destroy(questMark);
            Destroy(gameObject);
        }
    }
    //Nuestro trigger ha salido de esa colisión
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
