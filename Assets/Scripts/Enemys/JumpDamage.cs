using UnityEngine;

public class JumpDamage : MonoBehaviour
{
    //para animacion
    private Animator anim;
    private SpriteRenderer spriteRend;
    public GameObject destroyParticle;

    //impulso hacia arriba
    public float jumpForce = 5f;

    //vidas del enemigo
    public int lifes = 2;

    private void Start()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //si tiene tag player
        if (collision.transform.CompareTag("Player"))
        {
            //se hara un rebota hacia arriba cada que colisione
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
            //le hacemos dano y checkeamos cuanta vida le queda
            LoseLifeAndHit();
            CheckLife();
        }
    }

    //se restan vidas y se hace animacion hit
    public void LoseLifeAndHit()
    {
        lifes--;
        anim.Play("Hit");
    }

    public void CheckLife()
    {
        //si no tiene vida, hacemos una animacion identica a los objetos,
        //particulas de destruccion y se destruye gameObject despues de un tiempo
        if (lifes == 0)
        {
            destroyParticle.SetActive(true);
            spriteRend.enabled = false;
            Invoke("EnemyDie", 0.25f);
        }
    }

    //destruir gameObject
    public void EnemyDie()
    {
        Destroy(gameObject);
    }
}
