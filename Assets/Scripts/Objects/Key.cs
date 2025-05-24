using System.Collections;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 0, 0);
    public float followSpeed = 5f;

    public bool isFollowing = false;
    private bool isDisabling = false;

    private ParticleSystem particleSys;

    void Start()
    {
        //Busca en los hijos del objeto un sistema de particulas:
        particleSys = GetComponentInChildren<ParticleSystem>();
        if (particleSys != null)
            particleSys.Stop();
    }

    void Update()
    {
        if (isFollowing)
        {
            // Movimiento suave hacia el jugador:
            transform.position = Vector3.MoveTowards(transform.position, player.position + offset, followSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //si colisiona con un objeto con tag Player:
        if (other.CompareTag("Player"))
        {
            //Se activa el isFollowing y se desactiva el trigger pues no hará más falta:
            isFollowing = true;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    public void DisableKey()
    {
        //Si se usa la llave
        isDisabling = true;
        if (particleSys != null)
        {
            particleSys.Play();
            StartCoroutine(DestroyAfterParticles());
        }        
    }

    private IEnumerator DestroyAfterParticles()
    {
        float duration = particleSys.main.duration;
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
