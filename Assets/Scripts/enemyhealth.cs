using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    public GameObject collectibleAmmoPrefab,collectibleHealthPrefab;
    GamemanagerScript gameManager;
    public int health;
    public int scoreValue;
    public int type;
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
    //public void SpawnCollectibleAmmo()
    //{
    //    Instantiate(collectibleAmmoPrefab, transform.position, Quaternion.identity);
    //}
    //public void SpawnCollectibleHealth() {
    //    Instantiate(collectibleHealthPrefab, transform.position, Quaternion.identity);
    //}
    public void SpawnCollectible()
    {
        int randomNum;
        randomNum = Random.Range(0, 100);
        if (type == 1)
        {
         
            if (randomNum % 10 == 0)
            {
                Instantiate(collectibleAmmoPrefab, transform.position, Quaternion.identity);
            }

        }
        else if (type == 2)
        {
          
            if (randomNum % 5 == 0)
            {

                Instantiate(collectibleAmmoPrefab, transform.position, Quaternion.identity);
            }
            else if (randomNum % 10 == 0)
            {
                Instantiate(collectibleHealthPrefab, transform.position, Quaternion.identity);
            }
        }
        else if (type == 3)
        {
            
            if (randomNum % 3 == 0)
            {

                Instantiate(collectibleAmmoPrefab, transform.position, Quaternion.identity);
            }
            else if (randomNum % 5 == 0)
            {
                Instantiate(collectibleHealthPrefab, transform.position, Quaternion.identity);
            }
        }
        print(randomNum);
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
