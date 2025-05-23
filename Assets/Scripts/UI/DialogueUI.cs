using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{    
    //coge la script del movimiento del jugador en el inspector
    public PlayerMovement playerM;
    //Feedback para que el jugador pulse click para continuar
    public GameObject click;
    
    //asigna el texto donde estara el dialogo
    public TMP_Text textLabel;

    //hace una area en el inspector que puede alargarse hasta 3 sin scroll
    //(max de lineas que puede mostrar sin que se salga del rectangulo)
    [TextArea(1,3)]
    public string[] dialogue;
    //velocidad en la que va el texto al escribirse
    public float textSpeed = 0.1f;

    //index del dialogo que se va a mostrar dentro de la string de dialoue[]
    //y para saber si la coroutina esta en funcionamiento
    private int index;
    private Coroutine _isTyping;

    //Take the audio from another gameobject
    public AudioSource _audioSource;

    void Start()
    {
        if (playerM != null)
        {
            playerM.moveSpeed = 0.0f;
            playerM.animator.Play("Idle");
        }
        textLabel.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        //si apretamos el click derecho del raton
        if (Input.GetMouseButtonDown(0))
        {
            _audioSource.Stop();
            click.SetActive(true);
            //si se estaba haciendo una coroutina esta se para y se muestra todo el dialogo
            if (_isTyping != null)
            {
                StopCoroutine(_isTyping);
                textLabel.maxVisibleCharacters = textLabel.textInfo.characterCount;
                _isTyping = null;
            }
            //si no, muestra el siguiente dialogo en el index
            else
            {
                NextDialogue();
            }
        }
    }

    //funcion que hace empezar de 0 el dialogo
    void StartDialogue()
    {
        index = 0;
        ShowDialogue();
    }

    //funcion que hace que todas las letras del dialogo se vuelvan invisibles
    void ShowDialogue()
    {
        textLabel.text = dialogue[index];
        textLabel.maxVisibleCharacters = 0;
        //empieza la coroutina
        _isTyping = StartCoroutine(RevealCharacters());
    }

    //coroutina que hace visibles las letras una por una
    IEnumerator RevealCharacters()
    {
        //se actualiza el texto y se cuentan cuantas letras hay en el texto para meterlas en una variable
        textLabel.ForceMeshUpdate();
        int totalCharacters = textLabel.textInfo.characterCount;
        _audioSource.Play();
        click.SetActive(false);

        // variable que sirve de index para mostrar letra por letra hasta llegar al maximo a la velocidad del textSpeed
        int visibleCount = 0;
        while (visibleCount <= totalCharacters)
        {
            textLabel.maxVisibleCharacters = visibleCount;
            visibleCount++;
            yield return new WaitForSeconds(textSpeed);
        }

        _isTyping = null;
        _audioSource.Stop();
        click.SetActive(true);
    }

    //actualiza el index, si hay mas dialogo que mostrar, se suma el index y se muestra dicho nuevo dialogo,
    //si no, se destruye el objeto
    void NextDialogue()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            ShowDialogue();
        }
        else
        {
            if (playerM != null)
            {
                playerM.moveSpeed = 12.0f;
            }
            textLabel.text = string.Empty;
            Destroy(gameObject);
        }
    }
}