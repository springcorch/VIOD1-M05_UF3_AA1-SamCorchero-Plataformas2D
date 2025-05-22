using TMPro.Examples;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public GameObject dialogue1;
    public GameObject dialogue2;
    public GameObject player;
    public GameObject NPC;
    public CameraManager cam;

    // Start is called before the first frame update
    void Start()
    {
        dialogue1.SetActive(false);
        dialogue2.SetActive(false);
        cam.player = player;
    }

    void Update()
    {
        if (dialogue1 == null)
        {
            if (dialogue2 == null)
            {
                cam.player = player;
                Destroy(gameObject);
            }
            else
            {
                cam.player = NPC;
                dialogue2.SetActive(true);
            }
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { 
            dialogue1.SetActive(true);
        }
    }
}
