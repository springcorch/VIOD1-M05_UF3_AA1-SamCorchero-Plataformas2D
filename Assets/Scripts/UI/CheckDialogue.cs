using UnityEngine;

public class CheckDialogue : MonoBehaviour
{
    //questMark and dialogues marcable en el inspector
    public GameObject questMark;
    public GameObject dialogue1;
    private bool inDialogue = false;

    //Nuestro trigger ha entrado en una colisi�n
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If la colision detectada esta marcada con el tag Player
        if (collision.CompareTag("Player"))
        {
            //Se mostrara la questMark
            questMark.SetActive(true);
            inDialogue = true;
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
            inDialogue = false;
        }
    }

    void Update()
    {
        //Mientras el trigger este en contacto con la colisi�n
        if (inDialogue)
        {
            //si se pulsa "e" se activara el dialogo
            if (Input.GetKey("e"))
            {
                dialogue1.SetActive(true);
                Destroy(questMark);
                Destroy(gameObject);
            }
        }
    }
}
