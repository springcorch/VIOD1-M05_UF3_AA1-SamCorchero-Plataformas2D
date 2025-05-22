using UnityEngine;

public class TriggerSounds : MonoBehaviour
{
    private RandomClipPlayer _player;

    void Start()
    {
        _player = GetComponent<RandomClipPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            _player.PlayRandomClip();
        }
    }
}
