using UnityEngine;

public class CheckGround : MonoBehaviour
{
    //Confirmar que esta en el suelo (static para usarlo en otro script)
    public static bool isGrounded;

    //Nuestro trigger ha entrado en una colisión
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If la colision detectada esta marcada con el tag Ground
        if (collision.CompareTag("Ground"))
        {
            //Se detecta que el Player esta en el suelo
            isGrounded = true;
        }
    }

    //Nuestro trigger ha salido de esa colisión
    private void OnTriggerExit2D(Collider2D collision)
    {
        //If la colision detectada esta marcada con el tag Ground
        if (collision.CompareTag("Ground"))
        {
            //Se detecta que el Player esta en el aires
            isGrounded = false;
        }
    }

    //EXPLICACION DEL PROFESSOR - RAYCAST
    /*
    public Rayo[] rayos;

    [Serializable] //using System;
    public struct Rayo {
        public Vector3 origen; // 0, 0, 0; 0.2, 0, 0; 0, 0, 0.2
        public Vector3 direction; //0, -1, 0; 
        public float distance; //1.1, 1.1, 1.1
    }

    public static bool isGrounded = false;
    GameObject plataformaMovil = null;
    
     void Update(){
        foreach (Rayo rayo in rayos){
            Debug.DrawRay(
                transform.position + rayo.origen,
                rayo.direction.normalized * rayo.distance,
                Color.red);
        
            RaycastHit2D hit = 
                Physics2D.Raycast(
                  transform.position + rayo.origen,
                   rayo.direction.normalized,
                   rayo.distance);
            if(hit.collider.CompareTag("Ground")){
                Debug.DrawRay(
                transform.position + rayo.origen,
                rayo.direction.normalized * rayo.distance, 
                Color.green);
                isGrounded = true;
                if(hit.collider.hit == "PlataformaMovil"){
                    plataformaMovil = hit.collider.gameObject;
                }
            }
        }

        if (plataformaMovil != null) { 
            transform.parent = plataformaMovil.transform;
        }
        else
        {
            transform.parent = null;
        }

    }*/
}
