using System.Collections;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    //Para animaciones y giros si mira para un lado o otro
    private Animator anim;
    private SpriteRenderer spriteRend;

    //velocidad y espera que tiene el personaje en cada punto
    public float speed = 0.5f;
    private float waitTime;
    public float startWaitTime = 2f;

    //Puntos donde ira el personaje
    public Vector2[] wayPoints;

    private int i = 0;
    private Vector2 actualPos;

    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();

        waitTime = startWaitTime;
    }

    void Update()
    {
        //Courutina para girar al personaje si este esta mirando izquierda o derecha
        //y saber los estados de animacion de este
        StartCoroutine(CheckEnemyMove());

        //Se mueve a nueva localización empezando por la 0 (indicada en la variable i)
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[i], speed * Time.deltaTime);

        //Si se ha llegado a la posicion
        if (Vector2.Distance(transform.position, wayPoints[i]) < 0.1f)
        {
            //Se confirma que ha pasado el tiempo
            if (waitTime <= 0)
            {
                // Vamos al siguiente punto (si no hay mas puntos, vuelve al punto 0)
                if (wayPoints[i] != wayPoints[wayPoints.Length - 1])
                {
                    i++;
                }
                else {
                    i = 0;
                }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }

    IEnumerator CheckEnemyMove()
    {
        actualPos = transform.position;
        yield return new WaitForSeconds(0.5f);

        //derecha
        if (transform.position.x > actualPos.x)
        {
            spriteRend.flipX = false;
            anim.SetBool("Idle", false);
        }
        //izquierda
        else if (transform.position.x < actualPos.x)
        {
            spriteRend.flipX = true;
            anim.SetBool("Idle", false);
        }
        else if (transform.position.x == actualPos.x)
        {
            anim.SetBool("Idle", true);
        }
    }
}