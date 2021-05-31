using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    public GameObject collectiblePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Destroy(this.gameObject);
            SpawnCollectible();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void SpawnCollectible()
    {
        Instantiate(collectiblePrefab, transform.position, Quaternion.identity);
    }
    
}
