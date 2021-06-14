using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    public GameObject collectiblePrefab;
    GamemanagerScript gameManager;
    public int health;
    public int scoreValue;
    // Start is called before the first frame update
    void Start()
    {
        
        gameManager = GameObject.Find("GameManager").GetComponent<GamemanagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            health--;
            CheckEnemyHealth();
        }
        else
        {
           // Destroy(this.gameObject);
        }
    }
    public void SpawnCollectible()
    {
        Instantiate(collectiblePrefab, transform.position, Quaternion.identity);
    }
    public void CheckEnemyHealth()
    {
        if (health <= 0)
        {
            gameManager.Score += scoreValue;
            Destroy(this.gameObject);
            SpawnCollectible();
        }
    }
    
}
