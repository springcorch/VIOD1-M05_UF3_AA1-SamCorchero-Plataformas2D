using UnityEngine;

public class CheckGround : MonoBehaviour
{
    //Confirmar que esta en el suelo (static para usarlo en otro script)
    public static bool isGrounded;

    //Nuestro trigger ha entrado en una colisión
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If la colision detectada esta marcada con el tag Ground
        if (collision.CompareTag("Ground"))
        {
            //Se detecta que el Player esta en el suelo
            isGrounded = true;
        }
    }

    //Nuestro trigger ha salido de esa colisión
    private void OnTriggerExit2D(Collider2D collision)
    {
        //If la colision detectada esta marcada con el tag Ground
        if (collision.CompareTag("Ground"))
        {
            //Se detecta que el Player esta en el aires
            isGrounded = false;
        }
    }
}
