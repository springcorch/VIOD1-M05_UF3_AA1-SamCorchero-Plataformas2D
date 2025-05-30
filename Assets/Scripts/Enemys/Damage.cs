using UnityEngine;

public class Damage : MonoBehaviour
{
    //Nuestro collider ha entrado en una colision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //La colision tiene un tag Player
        if (collision.transform.CompareTag("Player"))
        {
            //Se reinicia escena
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
        }
    }
}
