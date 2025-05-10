using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{

    //Parametros para indicar la posicion del checkpoint en x y en y, estan en floats en vez de Vector2
    //porque los PlayerPrefs solo guardan floats o ints (en este caso, pueden guardar mas cosas), y preferia
    //que guardase un float en vez de un int.
    private float checkPointPosX, checkPointPosY;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //Comprobamos que se ha guardado algun "checkPointPosX", lo que significa que ha tocado un checkPoint
        if (PlayerPrefs.GetFloat("checkPointPosX") != 0)
        {
            //Mueve al jugador a la posicion establecida de el checkpoint
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPosX"), 
                                                PlayerPrefs.GetFloat("checkPointPosY")));
        }
    }

    //Funcion que guarda nueva posicion de checkpoint 
    public void checkPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPosX", x);
        PlayerPrefs.SetFloat("checkPointPosY", y);
    }

    //Funcion que hace una animacion de daño y recarga la escena de 0
    public void PlayerDamaged()
    {
        animator.Play("Hit");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}