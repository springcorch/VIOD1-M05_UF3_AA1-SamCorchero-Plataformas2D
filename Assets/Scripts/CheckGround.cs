using UnityEngine;

public class CheckGround : MonoBehaviour
{
    //Confirmar que esta en el suelo (static para usarlo en otro script)
    public static bool isGrounded;

    //Nuestro trigger ha entrado en una colisi�n
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }

    //Nuestro trigger ha salido de esa colisi�n
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
