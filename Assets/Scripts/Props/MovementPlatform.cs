using UnityEngine;

public class Movementplatform : MonoBehaviour
{
    //velocidad y espera que tiene el personaje en cada punto
    public float speed = 0.5f;
    private float waitTime;
    public float startWaitTime = 2f;

    //Puntos donde ira el personaje
    public Transform[] wayPoints;

    private int i = 0;

    void Start()
    {
        waitTime = startWaitTime;
    }

    void Update()
    {
        //Se mueve a nueva localización empezando por la 0 (indicada en la variable i)
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[i].transform.position, speed * Time.deltaTime);

        //Si se ha llegado a la posicion
        if (Vector2.Distance(transform.position, wayPoints[i].transform.position) < 0.1f)
        {
            //Se confirma que ha pasado el tiempo
            if (waitTime <= 0)
            {
                // Vamos al siguiente punto (si no hay mas puntos, vuelve al punto 0)
                if (wayPoints[i] != wayPoints[wayPoints.Length - 1])
                {
                    i++;
                }
                else
                {
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

    //Nos hara hijo de la plataforma y asi podremos movernos con tal plataforma
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(transform);
    }

    //Nos quitara de ser hijo de la plataforma
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(null);
    }
}
