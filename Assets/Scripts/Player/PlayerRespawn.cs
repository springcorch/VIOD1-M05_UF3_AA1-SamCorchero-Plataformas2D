using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    //Corazones y vida del jugador
    public GameObject[] hearts;
    private int life;

    //Impulso hacia atras al hacernos dano
    public float impulse = 5.0f;

    //Parametros para indicar la posicion del checkpoint en x y en y, estan en floats en vez de Vector2
    //porque los PlayerPrefs solo guardan floats o ints (en este caso, pueden guardar mas cosas), y preferia
    //que guardase un float en vez de un int.
    private float checkPointPosX, checkPointPosY;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public AudioSource audSource;

    // Start is called before the first frame update
    void Start()
    {
        //la vida es igual a la longitud de hearts que tengamos en nuestra array
        life = hearts.Length;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Comprobamos que se ha guardado algun "checkPointPosX", lo que significa que ha tocado un checkPoint
        if (PlayerPrefs.GetFloat("checkPointPosX") != 0)
        {
            //Mueve al jugador a la posicion establecida de el checkpoint
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPosX"), 
                                                PlayerPrefs.GetFloat("checkPointPosY")));
        }
    }

    //logica corazones
    private void CheckLife()
    {
        //si nos hacen dano, animacion de hit, quitamos un corazon
        if (life < 1)
        {
            animator.Play("Hit");
            Destroy(hearts[0].gameObject);
            Invoke("ResetScene", 0.25f);
        }
        else if (life < 2)
        {
            animator.Play("Hit");
            Destroy(hearts[1].gameObject);
        }
        else if (life < 3) {
            animator.Play("Hit");
            Destroy(hearts[2].gameObject);
        }
    }

    //Funcion que guarda nueva posicion de checkpoint 
    public void checkPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPosX", x);
        PlayerPrefs.SetFloat("checkPointPosY", y);
    }

    public void PlayerDamaged()
    {
        life--;
        audSource.Play();
        // Impulsa al personaje hacia arriba (logica trampoline)
        rb.velocity = (Vector2.up * impulse);
        CheckLife();
    }

    private void ResetScene()
    {
        //hace reset de la escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}