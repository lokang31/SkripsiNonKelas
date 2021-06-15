using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public string collectibleType;
    Healthmanager playerHealth;
    Shootscript shootScript;
    public int healthValue;
    public int ammoValue;
    public int maxAmmoValue;
    public int maxHealthValue;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        shootScript = GameObject.Find("Player").GetComponent<Shootscript>();
        playerHealth = GameObject.Find("Player").GetComponent<Healthmanager>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position) * 0.05f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            if(collectibleType == "Ammo")
            {
                if (shootScript.maxAmmo <= maxAmmoValue-ammoValue)
                {
                    shootScript.maxAmmo += ammoValue;
                } 
                else
                {
                    shootScript.maxAmmo = maxAmmoValue;
                }
            }
            else
            {
                if(playerHealth.currHealth <= maxHealthValue-healthValue)
                {
                    playerHealth.currHealth += healthValue;
                }
                else
                {
                    playerHealth.currHealth = maxHealthValue; 
                }
            }
        }
    }
}
