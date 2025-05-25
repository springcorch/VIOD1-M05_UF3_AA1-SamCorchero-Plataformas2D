using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{
    //variable para coger el textmeshpro del texto de victoria
    public TMP_Text lvlCleared;

    //Para el score (feedback)
    public TMP_Text scoreObjects;
    private int totalObjects;
    private int collectedObjects;

    //string vacia que se puede cambiar en el inspector para poner el nombre de de la escena que se quiera cambiar
    public string nameScene = "";

    private void Start()
    {
        totalObjects = transform.childCount;
    }

    private void Update() 
    {
        //Esta funcion hara que el objeto padre de los objetos recolectables mire si quedan hijos de este cada frame
        if (transform.childCount == 0)
        {
            //Se muestra texto de victoria
            lvlCleared.gameObject.SetActive(true);
            //activa la funcion de ChangeScene despues de un segundo
            Invoke("ChangeScene", 2);
        }

        //Va restando cuando vayamos cogiendo los objetos, haciendolo un contador
        collectedObjects = transform.childCount;
        //Muestra este texto en pantalla actualizado, los ints se vuelven strings para evitar fallos a la hora de mostrarse
        scoreObjects.text = "Kiwis: " + collectedObjects.ToString() + " / " + totalObjects.ToString();
    }

    //Funcion para cambiar de escena
    void ChangeScene()
    {
            SceneManager.LoadScene(nameScene);
    }

}