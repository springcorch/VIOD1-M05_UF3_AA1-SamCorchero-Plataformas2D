using UnityEngine;

public class Transition : MonoBehaviour
{
    //Trigger que hara cambiar de secuencia
    public GameObject trigger;
    public GameObject otherObject;
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        if (trigger == null) {
            Destroy(otherObject);
            anim.SetBool("isOutro", true);
        }
    }
}
