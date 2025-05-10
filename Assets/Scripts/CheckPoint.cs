using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //Nuestro trigger ha entrado en una colision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //La colision tiene un tag Player
        if (collision.CompareTag("Player"))
        {
            //Se hara la funcion de checkPoint pasando nuevas variables que actualizaran la pos del jugador al morir o
            //al iniciar de nuevo el juego
            collision.GetComponent<PlayerRespawn>().checkPoint(transform.position.x, transform.position.y);
            GetComponent<Animator>().enabled = true;
        }
    }
}