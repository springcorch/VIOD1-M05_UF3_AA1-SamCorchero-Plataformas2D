using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //velocidad en la que apunta al jugador
    public float alpha = 2.5f;
    public GameObject player;

    //la pos del player y de la cam
    private Vector2 targetPosition;
    private Vector2 currentPosition;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            //se configuran las pos de los dos gameObjects
            targetPosition = player.transform.position;
            currentPosition = transform.position;

            //a cada frame, la camara se movera al jugador (el vector3 para que no se mueva la z)
            transform.position = Vector2.Lerp(currentPosition, targetPosition, alpha * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        }
    }
}