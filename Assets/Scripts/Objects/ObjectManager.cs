using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{
    //variable para coger el textmeshpro del texto de victoria
    public TextMeshProUGUI lvlCleared;

    //string vacia que se puede cambiar en el inspector para poner el nombre de de la escena que se quiera cambiar
    public string nameScene = "";

    //Esta funcion hara que el objeto padre de los objetos recolectables mire si quedan hijos de este cada frame
    private void Update() 
    {
        //si no detecta que tiene ningun hijo
        if (transform.childCount == 0)
        {
            //Se muestra texto de victoria
            lvlCleared.gameObject.SetActive(true);
            //activa la funcion de ChangeScene despues de un segundo
            Invoke("ChangeScene", 1);
        }
    }

    //Funcion para cambiar de escena
    void ChangeScene()
    {
            SceneManager.LoadScene(nameScene);
    }

}