using UnityEngine;

public class Platform : MonoBehaviour
{
    //Referencia a nuestro platformEffector2D
    private PlatformEffector2D effector;

    //Esperar un tiempo antes de que nosotros podamos volver a bajar de la plataforma
    public float startWaitTime;
    private float waitedTime;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si se suelta cualquier de las dos teclas se resetea el tiempo
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp("s")) { 
            waitedTime = startWaitTime;
        }


        //Si se pulsa cualquier de las dos teclas
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            //el offset rotation hace una rotacion de 180, esto significa que el collider pasa a estar a abajo
            //y se puede bajar de la plataforma del mismo modo que subimos
            if (waitedTime <= 0) { 
                effector.rotationalOffset = 180f;
                waitedTime = startWaitTime;
            }
            else
            {
                waitedTime -= Time.deltaTime;
            }
        }
        //el offset rotation vuelve a 0, esto significa que el collider pasa a estar arriba
        //y se puede subir de la plataforma del mismo modo que bajamos
        if (Input.GetKey("space"))
        {
            effector.rotationalOffset = 0f;
        }
    }
}
