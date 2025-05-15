using UnityEngine;

public class Bulletenemy : MonoBehaviour
{
    //tiempo entre que ataque y esta en idle
    private float waitedTime;
    public float timeToAttack = 3f;

    private Animator anim;
    public GameObject bulletPrefab;

    public Transform launchSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        waitedTime = timeToAttack;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitedTime <= 0) {
            anim.Play("Attack");
            Invoke("LaunchBullet", 0.5f);
            waitedTime = timeToAttack;
        }
        else
        {
            waitedTime -= Time.deltaTime;
        }
    }

    public void LaunchBullet()
    {
        //nueva bala spawneara en la posicion del launchSpawn
        GameObject newBullet;
        newBullet = Instantiate(bulletPrefab, launchSpawnPoint.position, launchSpawnPoint.rotation);
    }

}
