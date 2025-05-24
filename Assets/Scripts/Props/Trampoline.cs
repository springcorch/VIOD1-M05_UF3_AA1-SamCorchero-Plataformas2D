using UnityEngine;

public class Trampoline : MonoBehaviour
{

    private Animator anim;
    private AudioSource aud;
    public float jumpForce = 2f;


    private void Start()
    {
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Colisionamos con un objeto Player
        if (collision.transform.CompareTag("Player")) {
            //Accedemos a su rigidbody y le damos un empuje hacia arriba
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
            aud.Play();
            anim.Play("Jump");
        }
    }
}
