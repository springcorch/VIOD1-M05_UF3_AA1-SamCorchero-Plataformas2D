using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables para el movimiento (move)
    public float moveSpeed = 2f;

    //Variables para el movimiento (jump)
    public float jumpSpeed = 3f;
    public float doubleJumpSpeed = 2.5f;

    private bool canDoubleJump;

    //El rigidbody de nuestro personaje
    private Rigidbody2D rb;
    //Animaciones para movimiento
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start() {
        //Busca los componentes en el objeto:
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    
    //Para el jump, hace mejor las comprobaciones
    private void Update() {
        //Movimiento vertical del personaje (cae por gravedad del rb):
        if (Input.GetKey("space"))
        {
            //Si toca el suelo - if
            if (CheckGround.isGrounded)
            {
                canDoubleJump = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
            else
            {
                //Si pulsamos otra vez space en el aire
                if (Input.GetKeyDown("space"))
                {
                    //Haremos doble salto y volveremos a no poder saltar otra vez
                    if (canDoubleJump)
                    {
                        animator.SetBool("DoubleJump", true);
                        rb.velocity = new Vector2(rb.velocity.x, doubleJumpSpeed);
                        canDoubleJump = false;
                    }
                }
            }
        }

        //Logica de animacion de salto
        if (!CheckGround.isGrounded)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (CheckGround.isGrounded)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", true);
        }

        //Si estamos cayendo (y < 0)
        if (rb.velocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
        //Si estamos subiendo (y > 0)
        else if (rb.velocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }
    }

    void FixedUpdate() {
        //Movimiento horizontal del personaje:
        //Derecha
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        //Izquierda
        else if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
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
    }
}