using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables para el movimiento (move)
    public float moveSpeed = 2f;

    //Variables para el movimiento (jump)
    public float jumpSpeed = 3f;
    public float doubleJumpSpeed = 2.5f;

    private bool canDoubleJump;

    //Variables para el movimiento (wall)
    public float wallSlidingSpeed = 1.25f;
    private bool isTouchingWall = false;
    private bool wallSliding;

    private bool rightWall;
    private bool leftWall;

    //El rigidbody de nuestro personaje
    private Rigidbody2D rb;
    //Animaciones para movimiento
    private SpriteRenderer spriteRenderer;
    public Animator animator;

    void Start() {
        //Busca los componentes en el objeto:
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    
    //Para el jump, hace mejor las comprobaciones
    private void Update() {
        //Movimiento vertical del personaje (cae por gravedad del rb):
        if (Input.GetKey("space") && !wallSliding)
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
        else {
            animator.SetBool("Falling", false);
        }

        //WALL SLIDING LOGIC
        if (isTouchingWall && !CheckGround.isGrounded) { 
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }

        if (wallSliding) {
            animator.Play("Wall");
            //Mathf.Clamp se utiliza para tener un movimiento constante y que no se note la diferencia con MaxValue
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

    }

    void FixedUpdate() {
        //Movimiento horizontal del personaje:
        //Derecha
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow) && !rightWall)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        //Izquierda
        else if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow) && !leftWall)
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

    //Mientras este en colision...
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RightWall"))
        {
            isTouchingWall = true;
            rightWall = true;
        }
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            isTouchingWall = true;
            leftWall = true;
        }
    }
    //Cuando se salga de la colision...
    private void OnCollisionExit2D(Collision2D collision)
    {
        isTouchingWall = false;
        leftWall = false;
        rightWall = false;
    }
}