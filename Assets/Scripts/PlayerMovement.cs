using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables para el movimiento (move)
    public float moveSpeed = 2;
    //Animaciones para movimiento
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    //Variables para el movimiento (jump)
    public float jumpSpeed = 3;

    //Multiplicadores para que depende como cliquemos el espacio vaya mas alto o mas bajo
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;

    //El rigidbody de nuestro personaje
    private Rigidbody2D rb;

    void Start() {
        //Busca los componentes en el objeto:
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate() {
        //Movimiento horizontal del personaje:
        //Derecha
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        //Izquierda
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        //Ninguna tecla
        else { 
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("Run", false);
        }

        //Movimiento vertical del personaje (cae por gravedad del rb):
        if (Input.GetKey("space") && CheckGround.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        if (!CheckGround.isGrounded)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (CheckGround.isGrounded) 
        {
            animator.SetBool("Jump", false);
        }

        //Mejorar el salto con las fisicas de la gravedad y el Vector.up que hace que solo afecte al +y
        //Salta mas alto al tener una gravedad menor
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
        }
        //Salta mas bajo al tener una gravedad mayor y esto ocurre si no hemos mantenido el espacio
        if (rb.velocity.y > 0 && !Input.GetKey("space"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
        }
    }
}