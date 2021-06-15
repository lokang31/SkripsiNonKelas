using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageDealt;
    Healthmanager playerHealth;
 
    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<Healthmanager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerHealth.currHealth -= damageDealt;
        }
    }
}
