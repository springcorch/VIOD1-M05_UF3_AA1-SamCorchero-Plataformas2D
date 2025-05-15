using UnityEngine;

public class Bullet : MonoBehaviour
{
    //velocidad de la bala
    public float speed = 2f;
    //vida de la bala antes de ser destruida
    public float lifeTime = 2f;
    //va a la izquierda o derecha, TODO// flip at Player pos
    public bool right;



    // Start is called before the first frame update
    void Start()
    {
        //Al iniciar el script ya le decimos que queremos que se destruya al pasar dicho tiempo
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        //va hacia la direccion right or left depende la bool de antes
        if (right)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
}
