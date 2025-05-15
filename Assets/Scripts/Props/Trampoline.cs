using UnityEngine;

public class Trampoline : MonoBehaviour
{

    private Animator anim;
    public float jumpForce = 2f;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Colisionamos con un objeto Player
        if (collision.transform.CompareTag("Player")) {
            //Accedemos a su rigidbody y le damos un empuje hacia arriba
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
            anim.Play("Jump");
        }
    }
}
