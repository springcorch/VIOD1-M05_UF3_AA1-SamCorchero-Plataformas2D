using UnityEngine;

public class ObjectCollected : MonoBehaviour
{

    private RandomClipPlayer _player;

    //Asegurarnos que al iniciar el programa, el collected este desactivado y el renderizado del objeto activo
    void Start()
    {
        _player = GetComponent<RandomClipPlayer>();

        GetComponent<SpriteRenderer>().enabled = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    //Nuestro trigger ha entrado en una colision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //La colision tiene un tag Player
        if (collision.CompareTag("Player"))
        {
            //Se desactiva el SpriteRender de nuestro objeto
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //Un scrip que reproduce un audio aleatorio de una array
            _player.PlayRandomClip();

            //Bye bye objeto
            Destroy(gameObject, 0.75f);
        }
    }
}
