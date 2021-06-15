using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowShoot : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    Rigidbody rb;
    public GameObject bulletPrefab;
    public GameObject shootPoint;
    public float bulletSpeed;
    float shootCooldown;
    public float cooldownTime;
    public int damageDealt;
    void Start()
    {
        shootCooldown = cooldownTime;
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        FollowPlayer();
    }
    public void FollowPlayer()
    {
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) > 5f)
        {

            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.001f);

        }
        else
        {
            rb.velocity = Vector3.zero;
        }
         transform.LookAt(player.transform);
     
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            other.GetComponent<Healthmanager>().currHealth--;
        }
    }
     void Shoot()
    {
        shootCooldown -= Time.deltaTime;
        if (shootCooldown <= 0f)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce((player.transform.position - transform.position) * bulletSpeed * Time.deltaTime,ForceMode.Impulse);
            bullet.GetComponent<EnemyBulletScript>().damageDealt = damageDealt;
            shootCooldown = cooldownTime;
            Destroy(bullet, 10f);
        }
       
    }
}
